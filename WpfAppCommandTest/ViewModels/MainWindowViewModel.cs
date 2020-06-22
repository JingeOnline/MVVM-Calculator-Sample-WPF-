using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppCommandTest.ICommands;

namespace WpfAppCommandTest.ViewModels
{
    class MainWindowViewModel:NotificationObject
    {
        private double input1;

        public double Input1
        {
            get { return input1; }
            set 
            { 
                input1 = value;
                this.OnPropertyChanged("Input1");
            }
        }

        private double input2;

        public double Input2
        {
            get { return input2; }
            set 
            { 
                input2 = value;
                this.OnPropertyChanged("Input2");
            }
        }

        private double result;

        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                this.OnPropertyChanged("Result");
            }
        }

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        //由于ExecuteAction的数据类型是Action<object>，所以要传入的方法也需要一个参数
        //只是这个参数没有使用
        private void Add(object parameter)
        {
            this.Result = this.input1 + this.input2;
        }
        private void Save(object parameter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
        }

        //在构造函数中关联Add方法和AddCommand
        public MainWindowViewModel()
        {
            this.AddCommand = new DelegateCommand();
            this.AddCommand.ExecuteAction = new Action<object>(this.Add);

            this.SaveCommand = new DelegateCommand();
            this.SaveCommand.ExecuteAction = new Action<object>(this.Save);
        }
    }
}
