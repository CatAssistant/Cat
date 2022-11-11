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
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Cat
{
    public partial class Main : Form
    {
        //Variables
        readonly SpeechRecognitionEngine Recognition = new SpeechRecognitionEngine();
        readonly SpeechSynthesizer Catt = new SpeechSynthesizer();
        readonly SpeechRecognitionEngine IdleRecognition = new SpeechRecognitionEngine();
        readonly Choices choices = new Choices("What time is it", "How are you" , "Hey cat", "Stop listening", "Stop talking", "Run a image search", "Run a search", "Launch game", "Open gmail", "Open outlook", "Open youtube", "Minimize U I", "Exit application");
        readonly Random random = new Random();
        readonly NotifyIcon notifyIcon = new NotifyIcon();
        int Timeout = 0;




        //Form Code
        public Main()
        {
            InitializeComponent();
        }




        private void Main_Load(object sender, EventArgs e)
        {
            //Initialize Tray Icon
            notifyIcon.Icon = Properties.Resources.logo;
            notifyIcon.Text = "Cat! Virtual Assistant";
            notifyIcon.Visible = false;
            notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);


            //Select Feminine TTS Voice & Initialize Main Speech Recognition Thread
            Catt.SelectVoiceByHints(VoiceGender.Female);
            Recognition.SetInputToDefaultAudioDevice();
            Recognition.LoadGrammarAsync(new Grammar(new GrammarBuilder(choices)));
            Recognition.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Recognition_SpeechRecognized);


            //Initialize Activation Phrase Speech Recognition Thread
            IdleRecognition.SetInputToDefaultAudioDevice();
            IdleRecognition.LoadGrammarAsync(new Grammar(new GrammarBuilder(choices)));
            IdleRecognition.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(IdleRecognition_SpeechRecognized);
            IdleRecognition.RecognizeAsync(RecognizeMode.Multiple);


            //Initialize event handler for minimization of form
            this.Resize += new EventHandler(FormMinimized);
        }




        // Assistant Commands & Functions
        private void Recognition_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Timeout = 0;
            SpeechRecognitionBox.Text = e.Result.Text;
            string query;
            switch (e.Result.Text)
            {
                case "Run a search":
                    Catt.SpeakAsync("What should I search for?");
                    query = FreeRecognition();
                    Process.Start($"https://www.bing.com/search?q={query}");
                    break;




                case "Run a image search":
                    Catt.SpeakAsync("What should I search for?");
                    query = FreeRecognition();
                    Process.Start($"https://www.bing.com/images/search?q={query}");
                    break;




                case "What time is it":
                    Catt.SpeakAsync($"It is currently {DateTime.Now:hh:mm tt}");
                    break;




                case "Stop listening":
                    ListenTimer.Stop();
                    Timeout = 0;
                    Recognition.RecognizeAsyncCancel();
                    IdleRecognition.RecognizeAsync(RecognizeMode.Multiple);
                    break;




                case "Stop talking":
                    Catt.SpeakAsyncCancelAll();
                    break;




                case "Launch Game":
                    Catt.SpeakAsync("What game should I launch?");
                    using (WebClient wc = new WebClient())
                    {
                        string game = GameRecognition();
                        //Download Steam App Library
                        if (game == null) { Catt.SpeakAsync("Sorry that game is not supported"); }

                        else
                        {
                            if (File.Exists("steamlib.json")) { }
                            else { wc.DownloadFile("https://api.steampowered.com/ISteamApps/GetAppList/v2/", "steamlib.json"); }

                            //Run Game
                            try
                            {
                                Process.Start($"steam://rungameid/{(int)JObject.Parse(File.ReadAllText("steamlib.json"))["applist"]["apps"].FirstOrDefault(a => (string)a["name"] == game)?["appid"]}");
                                Catt.SpeakAsync($"Launching {game}");
                            }

                            //Catch error that occurs if intepreted game does not exist
                            catch (System.ArgumentNullException) { Catt.SpeakAsync("An error occurred while fetching the game. please contact the developer if this issue persists."); }
                        }
                    }
                    break;




                case "How are you":
                    switch (random.Next(1, 3))
                    {
                        case 1:
                            Catt.SpeakAsync("I'm doing well! Thanks for asking.");
                            break;

                        case 2:
                            Catt.SpeakAsync("All systems operational.");
                            break;

                        case 3:
                            Catt.SpeakAsync("I feel great. Your concern is appreciated.");
                            break;
                    }
                    break;




                case "Open gmail":
                    Catt.SpeakAsync("Ok");
                    Process.Start("https://mail.google.com/mail/");
                    break;




                case "Open outlook":
                    Catt.SpeakAsync("Ok");
                    Process.Start("https://outlook.live.com/mail/0/");
                    break;




                case "Open youtube":
                    Catt.SpeakAsync("Ok");
                    Process.Start("https://youtube.com");
                    break;



                case "Minimize U I":
                    this.WindowState = FormWindowState.Minimized;
                    break;



                case "Exit application":
                    Catt.SpeakAsync("Goodbye");
                    Environment.Exit(0);
                    break;




                default:
                    break;
            }


        }






        //Functions
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
        private string GameRecognition()
        {
            using(SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(System.Globalization.CultureInfo.CurrentCulture))
            {
                string game;
                try
                {
                    Choices games = new Choices("Warframe", "C S GO", "M W 2", "Team Fortress 2", "G Mod", "Apex Legends", "Rust", "RuneScape");
                    recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(games)));
                    recognizer.SetInputToDefaultAudioDevice();
                    RecognitionResult result = recognizer.Recognize();
                    game = result.Text;

                    if (game == "C S GO") { game = "Counter-Strike: Global Offensive"; }

                    else if (game == "M W 2") { game = "Call of Duty®: Modern Warfare® II"; }

                    else if (game == "G Mod") { game = "Garry's Mod"; }
                    
                    SpeechRecognitionBox.Text = game;
                }

                catch (NullReferenceException)
                {
                    Catt.SpeakAsync("Sorry I couldn't find that game");
                    game = null;
                }
                return game;
            }
        }




        // Events
        private void FormMinimized(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
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
                    ListenTimer.Start();
                    break;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
        }




        //Timers
        private void ListenTimer_Tick(object sender, EventArgs e)
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
                    Timeout = 0;
                    try { IdleRecognition.RecognizeAsync(RecognizeMode.Multiple); }
                    catch (InvalidOperationException){}
                    break;
            }
        }
    }
}
