using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace eightBitGmailNotifierCsharpUart
{
    public partial class FrmMain : Form
    {
        string RxString;
        string access_token;

        // Google account client configuration; put here your client ID and client secret
        const string clientID = "";
        const string clientSecret = "";
        const string authorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";


        public FrmMain()
        {
            InitializeComponent();

            foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                cmbPort.Items.Add(portName);
            }

            if (cmbPort.Items.Count > 0)
            {
                cmbPort.SelectedIndex = 0;
            }

            cmbBaudRate.SelectedIndex = cmbBaudRate.Items.IndexOf("2400");
            cmbDataBits.SelectedIndex = cmbDataBits.Items.IndexOf("8");
            cmbStopBits.SelectedIndex = cmbStopBits.Items.IndexOf("2");
            cmbParity.SelectedIndex = cmbParity.Items.IndexOf("Odd");
            cmbAutoTime.SelectedIndex = cmbAutoTime.Items.IndexOf("10");
        }

        private void BtnSerialStart_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = cmbPort.Text;
                serialPort.BaudRate = int.Parse(cmbBaudRate.Text);
                serialPort.DataBits = int.Parse(cmbDataBits.Text);

                switch (cmbStopBits.Text)
                {
                    case "1":
                        serialPort.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "1.5":
                        serialPort.StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case "2":
                        serialPort.StopBits = System.IO.Ports.StopBits.Two;
                        break;
                    default:
                        serialPort.StopBits = System.IO.Ports.StopBits.None;
                        break;
                }

                switch (cmbParity.Text)
                {
                    case "Odd":
                        serialPort.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "Even":
                        serialPort.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "Mark":
                        serialPort.Parity = System.IO.Ports.Parity.Mark;
                        break;
                    case "Space":
                        serialPort.Parity = System.IO.Ports.Parity.Space;
                        break;
                    default:
                        serialPort.Parity = System.IO.Ports.Parity.None;
                        break;
                }

                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    btnSerialStart.Enabled = false;
                    btnSerialStop.Enabled = true;
                    stsPort.Text = "Port status: Open";
                    Logger("Port opening:","Successful");
                }            
            }
            catch (Exception ex)
            {
                stsPort.Text = "Port status: Error! " + ex.Message;
                Logger("Port opening:","Error: "+ex.Message);
            }
        }

        private void BtnSerialStop_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                btnSerialStart.Enabled = true;
                btnSerialStop.Enabled = false;
                txtLogger.ReadOnly = true;
                stsPort.Text = "Port status: Closed";
                Logger("Port closing:", "Successful");
            }
        }

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxString = serialPort.ReadExisting();
            Invoke(new EventHandler(DisplayText));
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen) 
            { 
                serialPort.Close(); 
            }
        }

        private void DisplayText(object sender, EventArgs e)
        {
            Logger("Serial data response:", "Received: \""+RxString+"\"");
        }

        /// <summary>
        /// Checks gmail for new mails using atom feed and sends message over serial port if connection is open.
        /// </summary>
        public void Check()
        {
            /// Structure of message is buffer of 68 chars in following order:
            /// 
            /// 1) 0x02 - agreed value with device to mark start of message transmit
            /// 2) 65 characters which are empty if 0 emails, otherwise in following order:
            ///     2.1) first set of 32 characters (length of LED display):
            ///         2.1.1) 28 characters of sender email address (padded right with empty spaces)
            ///         2.1.2) " 1/2"
            ///     2.2) '|' - agreed value with device to mark delimiter for LED display message
            ///     2.3) second set of 32 characters
            ///         2.3.1) 28 characters of email subject (padded right with empty spaces)
            ///         2.3.2) " 2/2"
            /// 3) 0x03 - agreed value with device to mark end of message transmit

            try
            {
                Output("Making API Call to Atom Feed...");

                // builds the  request
                string gmailAtomFeed = "https://mail.google.com/mail/feed/atom";

                // sends the request
                HttpWebRequest atomFeedRequest = (HttpWebRequest)WebRequest.Create(gmailAtomFeed);
                atomFeedRequest.Method = "GET";
                atomFeedRequest.Headers.Add(string.Format("Authorization: Bearer {0}", access_token));
                atomFeedRequest.ContentType = "application/x-www-form-urlencoded";
                atomFeedRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

                // gets the response
                WebResponse atomFeedResponse = atomFeedRequest.GetResponse();
                using (StreamReader atomFeedResponseReader = new StreamReader(atomFeedResponse.GetResponseStream()))
                {
                    XmlReader reader = XmlReader.Create(atomFeedResponseReader);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(reader);
                    doc.Save("AtomFeed.xml");

                    string message;
                    DataSet ds = new DataSet();
                    ds.ReadXml("AtomFeed.xml");
                    int newMailsCount = int.Parse(ds.Tables[0].Rows[0][2].ToString());
                    if (newMailsCount > 0)
                    {
                        DataTable dt = ds.Tables[3];
                        dt.Merge(ds.Tables[2]);
                        string email = dt.Rows[0][1].ToString();
                        string title = dt.Rows[0][3].ToString();
                        email = (email + "                            ").Substring(0, 28);
                        title = (title + "                            ").Substring(0, 28);
                        message = email + " 1/2|" + title + " 2/2";
                    }
                    else
                    {
                        message = "                                                                 ";
                    }

                    Logger("Check email status:", newMailsCount.ToString() + " unread emails");
                    if (!serialPort.IsOpen)
                    {
                        Logger("Transmit status:", "Port closed");
                    }
                    else
                    {
                        //Sending through Serial port

                        string newMailsCountFormatted = newMailsCount > 9 ? "." : newMailsCount.ToString();

                        char[] buff = new char[68];
                        buff[0] = (char)0x02;
                        buff[1] = newMailsCountFormatted.ToCharArray()[0];
                        for (int i = 0; i < message.Length; i++)
                        {
                            buff[2 + i] = message.ToCharArray()[i];
                        }
                        buff[67] = (char)0x03;

                        for (int i = 0; i < 68; i++)
                        {
                            serialPort.Write(buff, i, 1);
                            System.Threading.Thread.Sleep(10);
                        }
                        Logger("Transmit status:", "Sent \"" + message + "\"");
                    }
                }
            }
            catch (Exception ex)
            {
                stsGmail.Text = "Gmail status: Error! " + ex.Message;
                Logger("Mail check status:", "Error: " + ex.Message);
            }
        }

        public void Logger(string s1, string s2)
        {
            //txtLogger.AppendText(s1+"\t\t"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n");
            txtLogger.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n");
            txtLogger.AppendText(s1 + "\n");
            txtLogger.AppendText(s2+"\n");
            txtLogger.AppendText("\n");
            txtLogger.SelectionStart = txtLogger.Text.Length;
            txtLogger.SelectionLength = 0;
        }

        private void CbAuto_CheckedChanged(object sender, EventArgs e)
        {
            btnCheck.Enabled = !cbAuto.Checked;
            timer.Interval = int.Parse(cmbAutoTime.Text) * 1000;
            Logger("Auto check:", cbAuto.Checked ? "Turned on" : "Turned off");
            cmbAutoTime.Enabled = !cbAuto.Checked;
            timer.Enabled = cbAuto.Checked;
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            Check();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Check();
            timer.Enabled = cbAuto.Checked;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            BtnLogin.Enabled = false;
            DoOAuth();
        }

        #region OAuth for gmail, based on: https://github.com/googlesamples/oauth-apps-for-windows

        /// <summary>
        /// Appends the given string to the on-screen log, and the debug console.
        /// </summary>
        /// <param name="output">string to be appended</param>
        public void Output(string output)
        {
            Console.WriteLine(output);
        }

        /// <summary>
        /// Base64url no-padding encodes the given input buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string Base64urlencodeNoPadding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            // Converts base64 to base64url.
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");
            // Strips padding.
            base64 = base64.Replace("=", "");

            return base64;
        }

        /// <summary>
        /// Returns URI-safe data with a given input length.
        /// </summary>
        /// <param name="length">Input length (nb. output will be longer)</param>
        /// <returns></returns>
        public static string RandomDataBase64url(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return Base64urlencodeNoPadding(bytes);
        }

        /// <summary>
        /// Returns the SHA256 hash of the input string.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static byte[] Sha256(string inputString)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inputString);
            SHA256Managed sha256 = new SHA256Managed();
            return sha256.ComputeHash(bytes);
        }

        // ref http://stackoverflow.com/a/3978040
        public static int GetRandomUnusedPort()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        private async void DoOAuth()
        {
            // Generates state and PKCE values.
            string state = RandomDataBase64url(32);
            string code_verifier = RandomDataBase64url(32);
            string code_challenge = Base64urlencodeNoPadding(Sha256(code_verifier));
            const string code_challenge_method = "S256";

            // Creates a redirect URI using an available port on the loopback address.
            string redirectURI = string.Format("http://{0}:{1}/", IPAddress.Loopback, GetRandomUnusedPort());
            Output("redirect URI: " + redirectURI);

            // Creates an HttpListener to listen for requests on that redirect URI.
            HttpListener http = new HttpListener();
            http.Prefixes.Add(redirectURI);
            Output("Listening..");
            http.Start();

            // Creates the OAuth 2.0 authorization request.
            string authorizationRequest = string.Format("{0}?response_type=code&scope=https%3A%2F%2Fmail.google.com%2Fmail%2Ffeed%2Fatom&redirect_uri={1}&client_id={2}&state={3}&code_challenge={4}&code_challenge_method={5}",
                authorizationEndpoint,
                Uri.EscapeDataString(redirectURI),
                clientID,
                state,
                code_challenge,
                code_challenge_method);

            // Opens request in the browser.
            System.Diagnostics.Process.Start(authorizationRequest);

            // Waits for the OAuth authorization response.
            var context = await http.GetContextAsync();

            // Brings the App to Focus.
            Activate();

            btnCheck.Enabled = true;
            cbAuto.Enabled = true;

            cmbAutoTime.Enabled = true;

            // Sends an HTTP response to the browser.
            var response = context.Response;
            string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>");
            var buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                http.Stop();
                Output("HTTP server stopped.");
            });

            // Checks for errors.
            if (context.Request.QueryString.Get("error") != null)
            {
                Output(string.Format("OAuth authorization error: {0}.", context.Request.QueryString.Get("error")));
                return;
            }
            if (context.Request.QueryString.Get("code") == null
                || context.Request.QueryString.Get("state") == null)
            {
                Output("Malformed authorization response. " + context.Request.QueryString);
                return;
            }

            // extracts the code
            var code = context.Request.QueryString.Get("code");
            var incoming_state = context.Request.QueryString.Get("state");

            // Compares the receieved state to the expected value, to ensure that
            // this app made the request which resulted in authorization.
            if (incoming_state != state)
            {
                Output(string.Format("Received request with invalid state ({0})", incoming_state));
                return;
            }
            Output("Authorization code: " + code);

            // Starts the code exchange at the Token Endpoint.
            PerformCodeExchange(code, code_verifier, redirectURI);
        }

        async void PerformCodeExchange(string code, string code_verifier, string redirectURI)
        {
            Output("Exchanging code for tokens...");

            // builds the  request
            string tokenRequestURI = "https://www.googleapis.com/oauth2/v4/token";
            string tokenRequestBody = string.Format("code={0}&redirect_uri={1}&client_id={2}&code_verifier={3}&client_secret={4}&scope=&grant_type=authorization_code",
                code,
                Uri.EscapeDataString(redirectURI),
                clientID,
                code_verifier,
                clientSecret
                );

            // sends the request
            HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(tokenRequestURI);
            tokenRequest.Method = "POST";
            tokenRequest.ContentType = "application/x-www-form-urlencoded";
            tokenRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            byte[] _byteVersion = Encoding.ASCII.GetBytes(tokenRequestBody);
            tokenRequest.ContentLength = _byteVersion.Length;
            Stream stream = tokenRequest.GetRequestStream();
            await stream.WriteAsync(_byteVersion, 0, _byteVersion.Length);
            stream.Close();

            try
            {
                // gets the response
                WebResponse tokenResponse = await tokenRequest.GetResponseAsync();
                using (StreamReader reader = new StreamReader(tokenResponse.GetResponseStream()))
                {
                    // reads response body
                    string responseText = await reader.ReadToEndAsync();
                    Output(responseText);

                    // converts to dictionary
                    Dictionary<string, string> tokenEndpointDecoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

                    access_token = tokenEndpointDecoded["access_token"];
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Output("HTTP: " + response.StatusCode);
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            // reads response body
                            string responseText = await reader.ReadToEndAsync();
                            Output(responseText);
                        }
                    }

                }
            }
        }

        #endregion
    }
}
