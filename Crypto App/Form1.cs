using Jojatekok.PoloniexAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto_App
{
    public partial class Form1 : Form
    {
        private PoloniexClient PoloniexClient { get; set; }

        public Form1()
        {
            InitializeComponent();
            PoloniexClient = new PoloniexClient("", "");

            Task t = Task.Run(() =>
            {
                GetValues();
            });
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private async void GetValues()
        {
            while(true)
            {
                var markets = await PoloniexClient.Markets.GetSummaryAsync();
                this.textBox1.Invoke((MethodInvoker)delegate
                {
                    this.textBox1.Text = markets[new CurrencyPair("USDT", "BTC")].PriceLast.ToString("0.##");
                    this.textBox9.Text = markets[new CurrencyPair("USDT", "XRP")].PriceLast.ToString("0.####");
                    this.textBox6.Text = markets[new CurrencyPair("BTC", "XRP")].OrderTopSell.ToString("0.#########");
                    this.textBox4.Text = (markets[new CurrencyPair("USDT", "BTC")].OrderTopSell * markets[new CurrencyPair("BTC", "XRP")].OrderTopSell).ToString("0.###");
                    //this.textBox2.Text = markets[new CurrencyPair("USDT", "SYS")]?.PriceLast.ToString("0.####");
                    this.textBox5.Text = markets[new CurrencyPair("BTC", "SYS")].OrderTopSell.ToString("0.#########");
                    this.textBox3.Text = (markets[new CurrencyPair("USDT", "BTC")].OrderTopSell * markets[new CurrencyPair("BTC", "SYS")].OrderTopSell).ToString("0.###");
                });
                //textBox1.Text = markets[new CurrencyPair("USDT", "BTC")].OrderTopSell.ToString("0.##");
                Thread.Sleep(5000);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
