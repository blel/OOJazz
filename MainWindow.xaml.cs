using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OOJazz.BusinessLogic;

namespace OOJazz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MasterNoteRow masterNoteRow = new MasterNoteRow();

        List<IntervalType> intervals = new List<IntervalType>() {new Prime(),new MinorSecond(), new MajorSecond(), new MinorThird(), new MajorThird(),
                new PerfectFourth(), new Tritone(), new DiminishedFifth(), new PerfectFifth(), new AugmentedFifth(), new MinorSixth(), new MajorSixth(), new MinorSeventh(), new MajorSeventh()};

        Chord minor = new Chord("minor", new List<IntervalType>() { new MinorThird(), new PerfectFifth() });
   


        public MainWindow()
        {
            InitializeComponent();
            this.cmbNote.ItemsSource = Enum.GetValues(typeof(MasterNoteType)).Cast<MasterNoteType>();
            this.cmbIntervalType.ItemsSource = intervals.Select(cc => cc.GetType().Name);
            this.cmbAccidentials.ItemsSource = Enum.GetValues(typeof(Accidentials)).Cast<Accidentials>();

            
            
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (this.cmbNote.SelectedValue != null)
            {

                Note note = new Note((MasterNoteType)this.cmbNote.SelectedValue,
                    this.cmbAccidentials.SelectedValue == null ? 0 :
                    (Accidentials)this.cmbAccidentials.SelectedValue);
                //Interval interval = new Interval(note, this.cmbIntervalType.SelectedValue == null ? 0 :
                //    (IntervalType)this.cmbIntervalType.SelectedValue);

                IntervalType xx = (from cc in intervals
                    where cc.GetType().Name == cmbIntervalType.SelectedValue.ToString()
                    select cc).First();

                Note upperNote = masterNoteRow.GetIntervalUp(note, xx).UpperNote;
                this.txbResult.Text += String.Format("The upper note of the interval is: {0}\r\n", upperNote.MasterNoteType.ToString() + upperNote.Accidentials.ToString());


                //this.txbResult.Text += String.Format("Next Upper Root: {0}\r\n", masterNoteRow.GetNextUpperNoteType((MasterNoteType)this.cmbNote.SelectedValue).ToString());
                //this.txbResult.Text += String.Format("Half Step Count to next upper note: {0}\r\n", masterNoteRow.StepsToUpper((MasterNoteType)this.cmbNote.SelectedValue).ToString());
                //this.txbResult.Text += String.Format("Next Lower Root: {0}\r\n", masterNoteRow.GetNextLowerNoteType((MasterNoteType)this.cmbNote.SelectedValue).ToString());
                //this.txbResult.Text += String.Format("Half Step Count to next lower note: {0}\r\n", masterNoteRow.StepsToLower((MasterNoteType)this.cmbNote.SelectedValue).ToString());

                //this.txbResult.Text += String.Format("Steps between your note and a C: {0}\r\n", masterNoteRow.StepsBetween(((MasterNoteType)this.cmbNote.SelectedValue), MasterNoteType.C));

                this.txbResult.Text += String.Format("Scale: \r\n");
                DiatonicScale majorScale = new DiatonicScale(note);
                foreach (Note scaleNote in majorScale.Notes)
                {
                    this.txbResult.Text += String.Format("{0}{1} ", scaleNote.MasterNoteType.ToString(), scaleNote.Accidentials.ToString());
                }


                this.txbResult.Text += String.Format("\r\nMixo Scale: \r\n");
                DiatonicScale mixoScale = new DiatonicScale(note, new DiatonicMode(DiatonicModeTypes.Mixolydian));
                foreach (Note scaleNote in mixoScale.Notes)
                {
                    this.txbResult.Text += String.Format("{0}{1} ", scaleNote.MasterNoteType.ToString(), scaleNote.Accidentials.ToString());
                }

               // this.txbResult.Text += string.Format("Minor chord notes: {0},{1},{2}", minor.GetNotes(note).First(), minor.GetNotes(note).ElementAt(1),minor.GetNotes(note).ElementAt(2));

                


            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.txbResult.Text = string.Empty;
        }
    }
}
