using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConsumerSocialization
{
    public class MainPageData : INotifyPropertyChanged
    {
        StreamWriter log;
        private List<Stimulus> _allStimuli = new List<Stimulus>();
        public ObservableCollection<Stimulus> Stimuli { get; set; }
        public MainPageData()
        {
            Stimuli = new ObservableCollection<Stimulus>();
            for (int stimulusId = 1; stimulusId <= 8; stimulusId++)
            {
                _allStimuli.Add(new Stimulus(
                    stimulusId,
                    "Stimulus Name For Stimulus No. " + stimulusId,
                    "Stimulus Caption For Stimulus No. " + stimulusId,
                    "Assets/stimuli/stimulus-" + stimulusId + ".png",
                    "Assets/stimuli/stimulus-" + stimulusId + ".png",
                    new DateTime(),
                    stimulusId,
                    new List<String>(),
                    false,
                    stimulusId,
                    stimulusId
                    ));
            }
            PerformFiltering();
        }

        private void PerformFiltering()
        {
            if (_filter == null)
            {
                _filter = "";
            }
            var lowerCaseFilter = Filter.ToLowerInvariant().Trim();
            var result = _allStimuli.Where(d => d.StimuliNamesAsString.ToLowerInvariant().Contains(lowerCaseFilter)).ToList();
            var toRemove = Stimuli.Except(result).ToList();
            foreach (var x in toRemove)
                Stimuli.Remove(x);
            var resultCount = result.Count;
            for (int i = 0; i < resultCount; i++)
            {
                var resultItem = result[i];
                if (i + 1 > Stimuli.Count || !Stimuli[i].Equals(resultItem))
                {
                    Stimuli.Insert(i, resultItem);
                }
            }
        }
        private string _greeting;
        public string Greeting
        {
            get { return _greeting; }
            set
            {
                if (value == _greeting)
                    return;
                _greeting = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Greeting)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Stimulus _selectedStimulus;
        public Stimulus SelectedStimulus
        {
            get { return _selectedStimulus; }
            set
            {
                _selectedStimulus = value;
                if (value == null)
                    Greeting = "fuck off the value is null";
                else
                    Greeting = "fuck off the value is not null";
                    
            }
        }
        private string _filter;
        public string Filter
        {
            get { return _filter; }
            set
            {
                if (value == _filter)
                    return;
                _filter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filter)));

                PerformFiltering();
            }
        }

    }
}
