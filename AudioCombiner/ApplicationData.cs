using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioCombiner
{
    public class ApplicationData : INotifyPropertyChanged
    {

        protected string introFilePath = "select intro file";
        public string IntroFilePath {
            get { return introFilePath; }
            set {
                introFilePath = value;
                OnPropertyChanged("IntroFilePath");
            }
        }

        protected string outroFilePath = "select outro file";
        public string OutroFilePath {
            get { return outroFilePath; }
            set {
                outroFilePath = value;
                OnPropertyChanged("OutroFilePath");
            }
        }


        protected string outputDirectoryPath = "select output directory";
        public string OutputDirectoryPath {
            get { return outputDirectoryPath; }
            set {
                outputDirectoryPath = value;
                OnPropertyChanged("OutputDirectoryPath");
            }
        }

        public ObservableCollection<string> AudioFilePathes { get; private set; }

        
        public ApplicationData()
        {

            AudioFilePathes = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (null == this.PropertyChanged) return;
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
