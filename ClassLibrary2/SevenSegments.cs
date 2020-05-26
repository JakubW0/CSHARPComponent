using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Reflection;

/// <summary>
/// Author: Jakub Wójcik
/// </summary>
namespace SevenSegment
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SevenSegments : UserControl
    {
        private SevenSegment[] sevenSegment = null;
        private int componentWidth = 50;
        private Color backgroundColor = Color.Black;
        private Color backgroundColorStatic = Color.Black;
        private Color alarmUp = Color.Cyan;
        private Color alarmDown = Color.Blue;
        private double alarmMinimum = 0.0;
        private double alarmMaximum = 99.9;
        private Color segmentOnColor = Color.Red;
        private Color segmentOffColor = Color.IndianRed;
        private Padding padd;
        private Double valueSeg = 1.234;



        public SevenSegments()
        {
            SuspendLayout();
            Size = new Size(400, 150);
            Name = "SevenSegments";
            Resize += new EventHandler(SevenResize);
            ResumeLayout(false);
            TabStop = false;
            padd = new Padding(20, 20, 20, 20);
            NumberOfSegments(4);

        }

        /// <summary>
        /// Wydzialnie miejsca dla segmentów
        /// </summary>
        private void SetSpaceForAllSegments()
        {

            int segWidth = Width / sevenSegment.Length;
            componentWidth = segWidth;
            int widthIncrement = Width;
            for (int i = (sevenSegment.Length-1); i >= 0; i--) // -1 poniewaz index jest od 0
            {
                widthIncrement = widthIncrement - segWidth;
                sevenSegment[i].Left = widthIncrement;
                
                sevenSegment[i].Width = segWidth;
            }

        }
        /// <summary>
        /// inicjalizacja ilosci segmentów
        /// </summary>
        /// <param name="number"></param>
        private void NumberOfSegments(int number)
        {
            if (sevenSegment != null)  //usuwanie inicjalizacji obiektów, ważne przy zmianie ilosci wyświetlanych segmentów
                for (int i = 0; i < sevenSegment.Length; i++)
                {
                   sevenSegment[i].Dispose();
                }


            if (number <= 0) return;
            sevenSegment = new SevenSegment[number+1];

            for (int i = 0; i < number+1; i++)
            { // inicjalizowanie i nadawanie wlasciwosci komponentom

                sevenSegment[i] = new SevenSegment();
                sevenSegment[i].Parent = this;
                sevenSegment[i].Top = 0;
                sevenSegment[i].Height = Height;
                sevenSegment[i].Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
                sevenSegment[i].Visible = true;
            }
          
            
            SetSpaceForAllSegments();
            RefreshSegment();
            Value = valueSeg;
        }
        /// <summary>
        /// 
        ///odświeżanie właściwości dla komponentów
        /// </summary>
        private void RefreshSegment() 
        {
            for (int i = 1; i < sevenSegment.Length; i++) // +1 bo index 0 to minus, jest on odświeżany w innej metodzie
            {
                sevenSegment[i].Width = componentWidth;
                sevenSegment[i].Background = backgroundColor;
                sevenSegment[i].SegmentOFF = segmentOffColor;
                sevenSegment[i].SegmentON = segmentOnColor;
                sevenSegment[i].Padding = padd;

            }

        }
        /// <summary>
        /// Odświeżanie minusa, należy go odświeżać osobno
        /// </summary>
        private void RefreshMinus()
        {
            sevenSegment[0].Width = componentWidth;
            sevenSegment[0].Background = backgroundColor;
            sevenSegment[0].Padding = padd;
            sevenSegment[0].SegmentOFF = segmentOffColor;
            sevenSegment[0].SegmentON = segmentOnColor; RefreshSegment();
            sevenSegment[0].segmentForMinus = true;
        }
        /// <summary>
        /// settery i gettery dla właściwości
        /// </summary>

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; backgroundColorStatic = value; RefreshSegment(); RefreshMinus(); }
        }
        /// <summary>
        /// 
        /// 
        /// </summary>
        public Color SegmentOn
        {
            get { return segmentOnColor; }
            set { segmentOnColor = value; RefreshSegment(); RefreshSegment(); RefreshMinus(); }
        }
        /// <summary>
        /// 
        /// 
        /// </summary>
        public Color SegmentOff
        {
            get { return segmentOffColor; }
            set { segmentOffColor = value; RefreshSegment(); RefreshSegment(); RefreshMinus(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public Color AlaramUp
        {
            get { return alarmUp; }
            set { alarmUp = value; RefreshSegment(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public Color AlarmDown
        {
            get { return alarmDown; }
            set { alarmDown = value; RefreshSegment(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SegmentsWidth
        {
            get { return componentWidth; }
            set
            {
                componentWidth = value; 
                RefreshSegment(); RefreshMinus();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Double AlarmMinimum
        {
            get { return alarmMinimum; }
            set
            {
                alarmMinimum = value; RefreshSegment();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Double AlarmMaximum
        {
            get { return alarmMaximum; }
            set
            {
                alarmMaximum = value; RefreshSegment();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CountOfSegments
        {
            get { return sevenSegment.Length-1; } // (nie liczymy znaku minus który jest na indexie 0
            set { NumberOfSegments(value); RefreshSegment(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public Padding Padd
        {
            get { return padd; }
            set { padd = value; RefreshSegment(); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SevenResize(object sender, EventArgs e)
        {
            SetSpaceForAllSegments();
        }
        /// <summary>
        /// alaram dla komponentu, dźwięk ostrzegwaczy + zmiana tła
        /// </summary>
        /// <param name="d"></param>
        private void Alarm(double d)
        {
           
            if (d >= alarmMaximum)
            {
                SystemSounds.Exclamation.Play();
                backgroundColor = alarmUp;

            }
            else if (d <= alarmMinimum)
            {
                backgroundColor = alarmDown;
                SystemSounds.Exclamation.Play();

            }
            else
            {
          
                backgroundColor = backgroundColorStatic;

            }
        }
        /// <summary>
        ///  metoda odpowiedzialna za znak minus, właściwości oraz stan wyświetlania
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueToParse"></param>
        /// <returns></returns>
        private String Minus(double value,String valueToParse) 
        {
            
            if (value < 0)
            {

                sevenSegment[0].Width = componentWidth;
                sevenSegment[0].Background = backgroundColor;
                sevenSegment[0].Padding = padd;
                sevenSegment[0].SegmentOFF = segmentOffColor;
                sevenSegment[0].SegmentON = segmentOnColor;
                valueToParse = valueToParse.Remove(0, 1);
                sevenSegment[0].segmentForMinus = true;

            }
            else if (value >= 0)
            {

                sevenSegment[0].Width = componentWidth;
                sevenSegment[0].Background = backgroundColor;
                sevenSegment[0].Padding = padd;
                sevenSegment[0].SegmentOFF = segmentOffColor;
                sevenSegment[0].SegmentON = segmentOnColor;
                sevenSegment[0].segmentForMinus = false;
            }
            return valueToParse;
        }

        /// <summary>
        /// metoda nadawania wartości komponentom 
        /// </summary>
     
        public Double Value
        {
            get { return valueSeg; }
            set
            {
                Alarm(value); // pierw sprawdzamy czy wartosc nie zostala przekroczona
                //wartośc max i min alarmu ustawia użtykownik w właściwościah

                valueSeg = value;
                String valueToParse = valueSeg.ToString();
                //użylismy stringa by łatwiej można było zbadać łańcuch w poszukiwaniu przecinka

                valueToParse = Minus(value, valueToParse);
                //metoda od ustalania minusa
           

                int valueLength = valueToParse.Length;
                //długość naszego łańcucha znaków;
           
                int dott = -1; 
                //gdy nie ma przecinka zmienna dott zostaje na -1 by nigdy nie trafiła do wyświetlenia
                // zmienna dott jest tak naprawde indexem segmentu który ma zapalić kropke/przecinek

                for(int i= 0; i <= valueLength-1; i++)
                {//petla do sprawdzania kropki
                    if (valueToParse[i] == ',')
                    {
                        dott = i + 1;
                      valueToParse =  valueToParse.Remove(i, 1);
                        valueLength = valueLength - 1;
                    }
                }
              
                for (int i = 1; i <= sevenSegment.Length-1; i++)
                {//petla zaczyna sie od 1, ponieważ index 0 to minus który jest dodawany w innej metodzie,
                    if (i <= valueLength) // sprawdzanie czy liczba powinna być zapalona na segmencie
                    {
                        sevenSegment[i].ShowDot = false;
                        if (dott == i) // jeśli numer kropki(index dla segmentu) zgadza się z zmienną inkrementowaną pętli to zapalamy korpka
                            //linijka nad ifem jest po to by zgasic kropke gdy np nasza liczba się przesuneła z kropka np z 1,34 na 13,4
                        {
                            sevenSegment[i].ShowDot = true;
                        }
                   
                        sevenSegment[i].Value = Char.ToString(valueToParse[i-1]); // przypisanie z indexu łancucha do segmentu i-1 ponieważ zaczeliśmy
                        // z indexem i = 1 (by nie ruszać segmentu od minusa) a nasz index w łancuchu musi sie zaczynac od 0  
                    }
                    else  //jeśli liczba rozmiar łańcucha(bez kropki) jest mniejszy niż ilosc segmentów, nieużywane segmenty trzeba zgasić, error = cały zgaszony segment
                    {
                        sevenSegment[i].Value = "error";
                        sevenSegment[i].ShowDot = false;
                    }
                }
                RefreshSegment();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SevenSegments
            // 
            this.Name = "SevenSegments";
            this.ResumeLayout(false);

        }
    }


}
