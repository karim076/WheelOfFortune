using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace WheelOfFortune.ViewModel
{
    class WheelOfFortune : ObservableObject
    {
        // Nodig voor het uitvoeren van events / ticks
        DispatcherTimer dispatcherTimer;

        // Geeft aan wanneer het wiel terug is in beginpositie (in graden)
        private int maxDegrees = 360;

        // Een field voor de startsnelheid van het wiel
        public float startSpeed
        {
            get
            {
                return  10 + (float)((random.NextDouble() * 4) - 2);
            }
        }
        // Een string die bijhoudt hoeveel de speler de laatste keer
        // gewonnen heeft
        private int lastWin;
        public int LastWin
        {
            get { return lastWin; }
            set
            {
                SetProperty(ref lastWin, value);
                LastWinDisplayString = $"$ {lastWin}";
            }
        }
        public string LastWinDisplayString;

        // Een bool die bijhoudt of het wiel aan het draaien is.
        private bool spinning = false;

        // Een float die de huidige snelheid bijhoudt
        private float currSpeed = 0;

        // Een int die de huidige hoek in de gaten houdt.
        private float angle;
        public float Angle
        {
            get => angle;
            private set
            {
                // Stel de hoek in op 'value'
                SetProperty(ref angle, value);

                // Corrigeer the hoek, zodat deze nooit groter is dan 360 (maxDegrees)
                SetProperty(ref angle, angle % maxDegrees);
            }
        }


        // ICommands voor de knoppen
        public ICommand RotateCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand spinWheel { get; }
        public ICommand bankruptCommand { get; }

        // Random nummer generator maken
        Random random = new Random();

        /// <summary>
        /// Constructor for WheelOfFortune.
        /// Gets called everytime the program starts.
        /// </summary>
        public WheelOfFortune()
        {
            // Voeg de juiste methoden toe aan de ICommands
            RotateCommand = new RelayCommand(increaseAngle);
            ResetCommand = new RelayCommand(resetAngle);
            spinWheel = new RelayCommand(startSpinning);
            bankruptCommand = new RelayCommand(GradeBankrupt);
            // Start timers, zodat we tick-events kunnen gebruiken
            StartTimers();
        }

        /// <summary>
        /// Deze methode zorgt ervoor dat het wiel begint te draaien.
        /// </summary>
        public void GradeBankrupt()
        {
            Angle = 160;
            LastWin = checkPrize();
        }
        public void startSpinning()
        {
            // SPIN THE WHEEL!!!
            spinning = true;
            currSpeed = startSpeed;
            Debug.WriteLine($"spinWheel; currSpeed: {currSpeed}");
        }

        /// <summary>
        /// Deze methode zorgt ervoor dat het wiel één graad verder draait
        /// </summary>
        public void increaseAngle()
        {
            // Verhoog de hoek van het wiel met 1
            Angle++;
            Debug.WriteLine($"increaseAngle; Hoek: {Angle}");
            LastWin = checkPrize();
        }
        /// <summary>
        /// Deze methode reset de hoek van het wiel naar 0 graden
        /// </summary>
        public void resetAngle()
        {
            // Reset the wheel to its original speed and position
            Angle = 0;
            spinning = false;
            Debug.WriteLine($"resetAngle! Hoek: {Angle}");
        }


        /********************************************************
         *                                                      *
         * JE HOEFT NIET VERDER TE LEZEN DAN DIT.               *
         *                                                      *
         *                            Mag uiteraard wel...      *
         *                                                      *
         * *****************************************************/

        /// <summary>
        /// Controleert wat de speler gewonnen heeft.
        /// </summary>
        /// <returns></returns>
        public int checkPrize()
        {
            if (8 <= Angle && Angle < 23)
            {
                Debug.WriteLine("$ 600");
                return 600;
            } 
            else if (23 <= Angle && Angle < 38)
            {
                Debug.WriteLine("$ 300");
                return 300;
            } 
            else if (38 <= Angle && Angle < 53)
            {
                Debug.WriteLine("$ 700");
                return 700;
            }
            else if (53 <= Angle && Angle < 68)
            {
                Debug.WriteLine("$ 450");
                return 450;
            }
            else if (68 <= Angle && Angle < 83)
            {
                Debug.WriteLine("$ 350");
                return 350;
            }
            else if (83 <= Angle && Angle < 98)
            {
                Debug.WriteLine("$ 800");
                return 800;
            }
            else if (98 <= Angle && Angle < 113)
            {
                Debug.WriteLine("Loose a turn");
                return 0;
            }
            else if (113 <= Angle && Angle < 128)
            {
                Debug.WriteLine("$ 300");
                return 300;
            }
            else if (128 <= Angle && Angle < 143)
            {
                Debug.WriteLine("$ 400");
                return 400;
            }
            else if (143 <= Angle && Angle < 158)
            {
                Debug.WriteLine("$ 600");
                return 600;
            }
            else if (158 <= Angle && Angle < 173)
            {
                Debug.WriteLine("Bankrupt!");
                return -1;
            }
            else if (173 <= Angle && Angle < 188)
            {
                Debug.WriteLine("$ 900");
                return 900;
            }
            else if (188 <= Angle && Angle < 203)
            {
                Debug.WriteLine("$ 300");
                return 300;
            }
            else if (203 <= Angle && Angle < 218)
            {
                Debug.WriteLine("$ 500");
                return 500;
            }
            else if (218 <= Angle && Angle < 233)
            {
                Debug.WriteLine("$ 900");
                return 900;
            }
            else if (233 <= Angle && Angle < 248)
            {
                Debug.WriteLine("$ 300");
                return 300;
            }
            else if (248 <= Angle && Angle < 263)
            {
                Debug.WriteLine("$ 400");
                return 400;
            }
            else if (263 <= Angle && Angle < 278)
            {
                Debug.WriteLine("$ 550");
                return 550;
            }
            else if (278 <= Angle && Angle < 293)
            {
                Debug.WriteLine("$ 800");
                return 800;
            }
            else if (293 <= Angle && Angle < 308)
            {
                Debug.WriteLine("$ 500");
                return 500;
            }
            else if (308 <= Angle && Angle < 323)
            {
                Debug.WriteLine("$ 300");
                return 300;
            }
            else if (323 <= Angle && Angle < 338)
            {
                Debug.WriteLine("$ 500");
                return 500;
            }
            else if (338 <= Angle && Angle < 353)
            {
                Debug.WriteLine("$ 600");
                return 600;
            }
            else if ( ( 353 <= Angle && Angle < 368 ) || Angle <= 8)
            {
                Debug.WriteLine("$ 5000");
                return 5000;
            }
            return 0;
        }

        /// <summary>
        /// Start de timers, zodat we gebruik kunnen maken van 'timed events'
        /// </summary>
        public void StartTimers()
        {
            // Does a lot of things needed for timer; boring, don't read.

            // Maak een nieuwe timer (/stopwatch)
            dispatcherTimer = new DispatcherTimer();

            // Geef op welke methode uitgevoerd moet worden, op de 'tick';
            dispatcherTimer.Tick += dispatcherTimer_Tick;

            // Hoe vaak moet er een 'tick' gebeuren (days/hours/mins/seconds/miliseconds)
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);

            // Start de timer
            dispatcherTimer.Start();
        }

        /// <summary>
        /// Methode wordt iedere 'tick' uitgevoerd.
        /// </summary>
        public void spinWheel_tick()
        {
            if (spinning)
            {
                // Slow down wheel
                currSpeed = currSpeed - (currSpeed / 10);

                // Slow down, until speed is (smaller than) 0
                if (currSpeed < 0.1)
                {
                    spinning = false;
                    currSpeed = 0;

                    LastWin = checkPrize();
                }

                // Add the current speed to the current angle
                Angle = Angle + currSpeed;
            }
        }

        /// <summary>
        /// Wordt iedere tick uitgevoerd, voor alle timed events die
        /// moeten gebeuren als het wiel niet aan het 'spinnen' is.
        /// </summary>
        public void notSpinning_tick()
        {
            if (!spinning)
            {
                // Do nothing
            }
        }

        /// <summary>
        /// wordt iedere 'tick' uitgevoerd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dispatcherTimer_Tick(object sender, object e)
        {
            // Debug.WriteLine("Tick");
            notSpinning_tick();
            spinWheel_tick();
        }
    }
}
