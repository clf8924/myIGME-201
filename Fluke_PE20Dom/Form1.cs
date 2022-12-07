using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE20Dom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            // add the delegate method to be called after the webpage loads, set this up before Navigate()
            this.webBrowser1.DocumentCompleted += new
            WebBrowserDocumentCompletedEventHandler(this.WebBrowser1__DocumentCompleted);

            // if you want to use example.html from a local folder (saved in c:\temp for example):
            this.webBrowser1.Navigate("c:\\temp\\example.html");

            // or if you want to use the URL  (only use one of these Navigate() statements)
            this.webBrowser1.Navigate("people.rit.edu/dxsigm/example.html");
        }
        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection;
            HtmlElement htmlElement;

            htmlElement = webBrowser1.Document.Body.GetElementsByTagName("h1")[0];
            htmlElement.InnerHtml = "My UFO Page";

            htmlElementCollection = webBrowser1.Document.Body.GetElementsByTagName("h2");
            htmlElementCollection[0].InnerHtml = "My UFO Info";
            htmlElementCollection[1].InnerHtml = "My UFO Pictures";
            htmlElementCollection[2].InnerHtml = "";

            htmlElement = webBrowser1.Document.Body;
            htmlElement.Style = "font-family: sans-serif";
            htmlElement.Style += "color: #FF0000";

            htmlElement = webBrowser1.Document.Body.GetElementsByTagName("p")[0];
            htmlElement.InnerHtml = "Report your UFO sightings here: <a href='http://www.nuforc.org'>http://www.nuforc.org</a>";

            htmlElement.Style = "color: green";
            htmlElement.Style += "font-weight: bold";
            htmlElement.Style += "font-size: 2em";
            htmlElement.Style += "text-transform: uppercase";
            htmlElement.Style += "text-shadow: 3px 2px #A44";

            htmlElement = webBrowser1.Document.Body.GetElementsByTagName("p")[1];
            htmlElement.InnerHtml = "";

            HtmlElement newImage = webBrowser1.Document.CreateElement("img");
            newImage.SetAttribute("src", "https://i.guim.co.uk/img/media/26b02e1ade06fad41b87e5ef02f65bafb719acda/0_274_4456_2673/master/4456.jpg?width=620&quality=85&dpr=1&s=none");
            newImage.SetAttribute("alt", "A Real UFO!");
            htmlElement = webBrowser1.Document.Body.GetElementsByTagName("p")[2];
            htmlElement.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, newImage);

            HtmlElement footer = webBrowser1.Document.CreateElement("footer");
            footer.InnerHtml = "&copy;2022 Collin Fluke";
            htmlElement = webBrowser1.Document.Body;
            htmlElement.AppendChild(footer);
        }
    }
}
