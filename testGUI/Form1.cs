using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace testGUI
{
    public partial class Form1 : Form
    {
        SearchPanel m_srchPanel;
        Gecko.GeckoWebBrowser m_wb;
        public Form1()
        {
            InitializeComponent();

            //m_srchPanel = new SearchPanel(cnnStr, false);
            //m_srchPanel.OnSelectTitle += (s, e) =>
            //{
            //    Debug.WriteLine("titleId {0}", e);
            //};
            //this.Controls.Add(m_srchPanel.m_tblLayout);
            //this.AcceptButton = m_srchPanel.m_acceptBtn;

            m_wb = new Gecko.GeckoWebBrowser();
            m_wb.Dock = DockStyle.Fill;
            //m_wb.AddMessageEventListener("func1", onFunc1);
            //wb.DomClick += Wb_DomClick;
            //wb.LoadHtml("<html><body></body></html>", "http://blank");
            this.Controls.Add(m_wb);
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if false
        //LoadHtml() throw assert
            m_wb.LoadHtml(@"<!DOCTYPE html>
             <html><head>
             <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
             <script type=""text/javascript"">
                function fireEvent(name, data)
                {
                   var event = new MessageEvent(name,{'view': window, 'bubbles': false, 'cancelable': false, 'data': data});
                   document.dispatchEvent(event);
                }
             </script>
             </head>
             <body>fdsfsda
                <input type=""button"" onclick=""fireEvent('myFunction', 'some data');"" value=""SHOW DATA"" />
             </body></html>"
            );

            m_wb.AddMessageEventListener("myFunction", ((string s) => MessageBox.Show(s)));
#endif

            m_wb.AddMessageEventListener("func1", onFunc1);
            m_wb.Navigate(@"C:\temp\until\KinhNikaya\testGUI\click.html");
        }

        private void onFunc1(string p)
        {
            MessageBox.Show(p);
        }

        private void Wb_DomClick(object sender, Gecko.DomMouseEventArgs e)
        {
            var msg = e.Button.ToString();
            var tar = e.Target.ToString();
            var el = e.Target.CastToGeckoElement();
            var tag = el.TagName;
            var type = el.GetAttribute("type");
            var id = el.GetAttribute("id");
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var lvi = new ListViewItem();
            //lvi.Text = "1";
            //listView2.Items.Add(lvi);
            //m_wb.AddMessageEventListener("func1", onFunc1);
            //m_wb.Navigate(@"C:\temp\until\KinhNikaya\testGUI\click.html");
            
        }

        string cnnStr
        {
            get
            {
                string srcDb = @"..\..\..\..\truongbo.accdb";
                var cnnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=<db>;";
                return cnnStr.Replace("<db>", srcDb);
            }
        }

        void testHeap()
        {
            int[] arr = new int[10];
            var rnd = new Random(101);
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rnd.Next(1, 100);
            }
            Func<int, int, int> cmp = (x, y) => x - y;
            var h = new MyHeap<int>(arr, cmp);
            for (int i = 0; i < 10; i++)
            {
                var min = h.PopMin();
            }
        }
    }
}
