using BTC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTC_WindowsForms
{
    public partial class frmbtc : Form
    {
        public frmbtc()
        {
            InitializeComponent();
        }

        string url_BTC = "http://api.coindesk.com/v1/bpi/currentprice.json";

        private void button1_Click(object sender, EventArgs e)
        {
            //string json;

            //using (var web = new System.Net.WebClient())
            //{
            //    var url = @"https://api.coindesk.com/v1/bpi/currentprice.json";
            //    web.
            //    json = web.DownloadString(url);
            //}

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = (new WebClient()).DownloadString(url_BTC);


            //  dynamic result = JsonValue.Parse(webClient.DownloadString("https://api.foursquare.com/v2/users/self?oauth_token=XXXXXXX"));
            // Console.WriteLine(result.response.user.firstName);

            //Response.Write(json);


            //MessageBox.Show(json);
            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            string currentPrice = obj.bpi.USD.rate.Value;//Convert.ToDecimal(obj.bpi.USD.rate.Value);
                                                         //30,104.3060
            currentPrice = currentPrice.Replace('.', '/');
            currentPrice = currentPrice.Replace(',', ' ');
            currentPrice = currentPrice.Replace(" ", "");
            //currentPrice = currentPrice.Trim();

            //  30 110/6680

            double btc = Convert.ToDouble(currentPrice);
            MessageBox.Show(currentPrice.ToString());
            //Console.WriteLine(currentPrice);
        }


        bool flag = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity = .50;

            try
            {
                if (flag == false)
                {
                    Thread thread_process_Data = new Thread(() => processData());
                    thread_process_Data.Start();
                }
            }
            catch { }



        }


        

        
        public static string check2digit(string number)
        {
            string ret = number;
            if (number.Length == 1)
            {
                ret = "0" + number;
            }

            return ret;
        }

        private void processData()
        {

            string line_err = "0";
            try
            {
                //if (checkBox1.Checked == true)
                //{
                //    listBox1.Items.Add(" Start " + DateTime.Now.ToString());
                //}

                //if (flag == true)
                //    return;

                line_err = "1";
                flag = true;




                    ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                string json = (new WebClient()).DownloadString(url_BTC);

                    dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    string currentPrice = obj.bpi.USD.rate.Value;//Convert.ToDecimal(obj.bpi.USD.rate.Value);
                                                                 //30,104.3060
                    //currentPrice = currentPrice.Replace('.', '/');
                    currentPrice = currentPrice.Replace(',', ' ');
                    currentPrice = currentPrice.Replace(" ", "");

                    
               

                //checkBox1.BeginInvoke(new Action(delegate ()
                //{
                    //    show_data = checkBox1.Checked ;
                    label1.BeginInvoke(new Action(delegate ()
                    {
                        //if (checkBox1.Checked == true)
                        //{
                            label1.Text = currentPrice.ToString() ;
                        //}
                    }));
                //}));

                DateTime _date_time = new DateTime();
                _date_time = DateTime.Now;


               string _date = _date_time.Year.ToString() + check2digit(_date_time.Month.ToString()) + check2digit(_date_time.Day.ToString()) + check2digit(_date_time.Hour.ToString()) + check2digit(_date_time.Minute.ToString()) + check2digit(_date_time.Second.ToString());



                label2.BeginInvoke(new Action(delegate ()
                {
                   label2.Text = check2digit(_date_time.Hour.ToString()) + ":"+check2digit(_date_time.Minute.ToString()) + ":"+check2digit(_date_time.Second.ToString());
                }));

            }
            catch (Exception ex)
            {


               
               // FacErrorLogUpdate _FacErrorLogUpdate = new FacErrorLogUpdate(GetConnectionString());
               // _FacErrorLogUpdate.tbl_CodeInsertLogError("Line error = " + line_err, "RahyabWinService_processData", ex.Message.ToString());
                flag = false;
            }
            flag = false;
        }

       

        public static string getWebResponse(string url)
        {
            // create request..
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            // use GET method
            webRequest.Method = "GET";

            // POST!
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            // read response into StreamReader
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader _responseStream = new StreamReader(responseStream);

            // get raw result
            return _responseStream.ReadToEnd();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //string byc = getWebResponse("https://bittrex.com/api/v1.1/public/getticker?market=BTC-BYC");
            string byc = getWebResponse(url_BTC);
            MessageBox.Show(byc);
        }

       

    
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            Opacity = 1;
        }
    }
}
