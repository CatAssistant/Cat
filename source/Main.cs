using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace Cat
{
    public partial class Main : Form
    {
        SpeechRecognitionEngine Recognition = new SpeechRecognitionEngine();
        SpeechSynthesizer Catt = new SpeechSynthesizer();
        SpeechRecognitionEngine IdleRecognition = new SpeechRecognitionEngine();
        Choices choices = new Choices("What time is it", "How are you" , "Hey cat", "Stop listening", "Stop talking", "Image search", "Exit");
        int Timeout = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Catt.SelectVoiceByHints(VoiceGender.Female);
            Recognition.SetInputToDefaultAudioDevice();
            Recognition.LoadGrammarAsync(new Grammar(new GrammarBuilder(choices)));
            Recognition.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Recognition_SpeechRecognized);
            //Recognition.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(Recognition_SpeechDetected);
            Recognition.RecognizeAsync(RecognizeMode.Multiple);

            IdleRecognition.SetInputToDefaultAudioDevice();
            IdleRecognition.LoadGrammarAsync(new Grammar(new GrammarBuilder(choices)));
            IdleRecognition.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(IdleRecognition_SpeechRecognized);
        }

        

        private void Recognition_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Timeout = 0;
            SpeechRecognitionBox.Text = e.Result.Text;
            switch (e.Result.Text)
            {
                case "Image search":
                    Catt.SpeakAsync("What should I search for?");
                    string query = FreeRecognition();
                    Process.Start($"https://www.bing.com/images/search?q={query}");
                    break;

                case "What time is it":
                    Catt.SpeakAsync($"It is currently {DateTime.Now.ToString("hh:mm tt")}");
                    break;



                case "Stop listening":
                    Recognition.RecognizeAsyncCancel();
                    IdleRecognition.RecognizeAsync(RecognizeMode.Multiple);
                    break;



                case "Stop talking":
                    Catt.SpeakAsyncCancelAll();
                    break;



                case "Exit":
                    Catt.Speak("Goodbye");
                    Environment.Exit(0);
                    break;



                default:
                    break;
            }


        }

        private void Recognition_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void IdleRecognition_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "Hey cat":
                    IdleRecognition.RecognizeAsyncCancel();
                    Catt.SpeakAsync("How can I help you?");
                    Recognition.RecognizeAsync(RecognizeMode.Multiple);
                    Timeout = 0;
                    break;
            }
        }

        private void TmrSpeaking_Tick(object sender, EventArgs e)
        {
            Timeout += 1;
            TimeoutDisplay.Text = Timeout.ToString();
            switch (Timeout)
            {
                case 10:
                    Recognition.RecognizeAsyncCancel();
                    break;

                case 11:
                    ListenTimer.Stop();
                    IdleRecognition.RecognizeAsync(RecognizeMode.Multiple);
                    Timeout = 0;
                    break;
            }
        }

        private string FreeRecognition()
        {
            using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(System.Globalization.CultureInfo.CurrentCulture))
            {
                recognizer.LoadGrammar(new DictationGrammar());
                recognizer.SetInputToDefaultAudioDevice();
                RecognitionResult result = recognizer.Recognize();
                return result.Text;
            }
        }
    }
}
