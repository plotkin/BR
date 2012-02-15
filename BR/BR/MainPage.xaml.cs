using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.IO;
using BR.model;

namespace BR
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Конструктор
        public MainPage()
        {
            InitializeComponent();
        }

        private void openText_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile myIS = IsolatedStorageFile.GetUserStoreForApplication();
            var uribook  = new Uri("books/test.txt", UriKind.Relative);
            var sr = Application.GetResourceStream(uribook);
            using (var br = new BinaryReader(sr.Stream))
            {
                var data = br.ReadBytes((int)sr.Stream.Length);
                ForReadingFiles.saveFileToIStore("test", data);
            }

            this.NavigationService.Navigate(new Uri("/forText.xaml", UriKind.Relative));
        }
    }
}