using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Microsoft.Speech.Recognition;

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class VoiceControl
    {
        
        static string l = "";
        static bool isEdit = false;

        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.5)
            {
                l = e.Result.Text;
                isEdit = true;
            }

        }

        public string VoiceContr(object sender, EventArgs e)
        {
            

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-ru");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();

            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);

            
            Choices numbers = new Choices();
            numbers.Add(new string[] { "добавить", "удалить", "изменить", "сохранить", "открыть" });


            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(numbers);


            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);

            sre.RecognizeAsync(RecognizeMode.Single);
            if (isEdit == true)
            {
                isEdit = false;
                return l;
            }
            else return "";
        }

        
    }
}
