using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task10
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<MessageModel> messageModelList;
        private TelegramService telegramService;
        public MainWindow()
        {
            this.InitializeComponent();

            this.messageModelList = new ObservableCollection<MessageModel>();
            this.telegramService = new TelegramService(this);
            this.listBox.ItemsSource = this.messageModelList;
        }

        private void sendMsgBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.listBox.SelectedItem is null)
            {
                MessageBox.Show("Выберите сообщение чтобы определить получателя");
                return;
            }

            var id = ((MessageModel)this.listBox.SelectedItem).Id;
            var text = this.textBox.Text;
            this.telegramService.SendText(id, text);
        }
    }
}
