using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toub.Sound.Midi;

namespace EarTrainer
{
    class Model
    {
        private const int channel = 1;
        private const int deltaTime = 0;
        private const int finishTime = 2000;
        private const int intervalTime = 1000;
        private const int maxVolume = 127;
        private const int middleC = 39;
        private const int octave = 12;

        private int note1 = middleC;
        private int note2 = middleC;
        private Random random = new Random();
        private bool isInterval = false;

        private int GetInterval(string intervalName)
        {
            Dictionary<string, int> intervalNames = new Dictionary<string, int>()
            {
                {"P1", 0},
                {"m2", 1},
                {"M2", 2},
                {"m3", 3},
                {"M3", 4},
                {"P4", 5},
                {"A4", 6},
                {"P5", 7},
                {"m6", 8},
                {"M6", 9},
                {"m7", 10},
                {"M7", 11},
                {"P8", 12}
            };

            return intervalNames[intervalName];
        }

        private string GetIntervalName(int interval)
        {
            Dictionary<int, string> intervals = new Dictionary<int, string>()
            {
                {0, "P1"},
                {1, "m2"},
                {2, "M2"},
                {3, "m3"},
                {4, "M3"},
                {5, "P4"},
                {6, "A4"},
                {7, "P5"},
                {8, "m6"},
                {9, "M6"},
                {10, "m7"},
                {11, "M7"},
                {12, "P8"}
            };

            return intervals[interval];
        }

        private int GetNote(string noteName)
        {
            Dictionary<string, int> noteNames = new Dictionary<string, int>()
            {
                {"C3", 27},
                {"C#3", 28},
                {"D3", 29},
                {"D#3", 30},
                {"E3", 31},
                {"F3", 32},
                {"F#3", 33},
                {"G3", 34},
                {"G#3", 35},
                {"A3", 36},
                {"A#3", 37},
                {"B3", 38},
                {"C4", 39},
                {"C#4", 40},
                {"D4", 41},
                {"D#4", 42},
                {"E4", 43},
                {"F4", 44},
                {"F#4", 45},
                {"G4", 46},
                {"G#4", 47},
                {"A4", 48},
                {"A#4", 49},
                {"B4", 50},
                {"C5", 51},
                {"C#5", 52},
                {"D5", 53},
                {"D#5", 54},
                {"E5", 55},
                {"F5", 56},
                {"F#5", 57},
                {"G5", 58},
                {"G#5", 59},
                {"A5", 60},
                {"A#5", 61},
                {"B5", 62},
                {"C6", 63}
            };

            return noteNames[noteName];
        }

        private string GetNoteName(int note)
        {
            Dictionary<int, string> notes = new Dictionary<int, string>()
            {
                {27, "C3"},
                {28, "C#3"},
                {29, "D3"},
                {30, "D#3"},
                {31, "E3"},
                {32, "F3"},
                {33, "F#3"},
                {34, "G3"},
                {35, "G#3"},
                {36, "A3"},
                {37, "A#3"},
                {38, "B3"},
                {39, "C4"},
                {40, "C#4"},
                {41, "D4"},
                {42, "D#4"},
                {43, "E4"},
                {44, "F4"},
                {45, "F#4"},
                {46, "G4"},
                {47, "G#4"},
                {48, "A4"},
                {49, "A#4"},
                {50, "B4"},
                {51, "C5"},
                {52, "C#5"},
                {53, "D5"},
                {54, "D#5"},
                {55, "E5"},
                {56, "F5"},
                {57, "F#5"},
                {58, "G5"},
                {59, "G#5"},
                {60, "A5"},
                {61, "A#5"},
                {62, "B5"},
                {63, "C6"}
            };

            return notes[note];
        }

        public void Play()
        {
            MidiPlayer.OpenMidi();
            MidiPlayer.Play(new NoteOn(deltaTime,
                                       channel,
                                       GetNoteName(note1),
                                       maxVolume));

            if (isInterval)
            {
                System.Threading.Thread.Sleep(intervalTime);
                MidiPlayer.Play(new NoteOff(deltaTime,
                                            channel,
                                            GetNoteName(note1),
                                            maxVolume));
                MidiPlayer.Play(new NoteOn(deltaTime,
                                           channel,
                                           GetNoteName(note2),
                                           maxVolume));
            }

            System.Threading.Thread.Sleep(finishTime);
            MidiPlayer.CloseMidi();
        }

        public void Play(string note1)
        {
            MidiPlayer.OpenMidi();
            MidiPlayer.Play(new NoteOn(deltaTime,
                                       channel,
                                       note1,
                                       maxVolume));
            System.Threading.Thread.Sleep(finishTime);
            MidiPlayer.CloseMidi();
        }

        public void Play(string note1, string interval, string direction)
        {
            MidiPlayer.OpenMidi();
            MidiPlayer.Play(new NoteOn(deltaTime,
                                       channel,
                                       note1,
                                       maxVolume));
            System.Threading.Thread.Sleep(intervalTime);
            MidiPlayer.Play(new NoteOff(deltaTime,
                                        channel,
                                        note1,
                                        maxVolume));
            int directionalInterval = GetInterval(interval);

            if (direction == "Down")
            {
                directionalInterval *= -1;
            }

            string note2 = GetNoteName(GetNote(note1) + directionalInterval);
            MidiPlayer.Play(new NoteOn(deltaTime,
                                        channel,
                                        note2,
                                        maxVolume));
            System.Threading.Thread.Sleep(finishTime);
            MidiPlayer.CloseMidi();
        }

        private int GetRandomInterval()
        {
            int randomInterval = random.Next(-1 * octave, octave + 1);
            return randomInterval;
        }

        private int GetRandomNote1()
        {
            int randomNote1Int = random.Next(middleC, middleC + octave + 1);
            return randomNote1Int;
        }

        public string GetString()
        {
            if (isInterval)
            {
                string interval = GetIntervalName(Math.Abs(note1 - note2));
                string direction = "Up";

                if (note2 < note1)
                {
                    direction = "Down";
                }

                string note1Name = GetNoteName(note1);
                string note2Name = GetNoteName(note2);
                string intervalString = interval +
                                        " " +
                                        direction +
                                        ": " +
                                        note1Name +
                                        " -> " +
                                        note2Name;
                return intervalString;
            }
            else
            {
                string note1Name = GetNoteName(note1);
                return note1Name;
            }
        }

        public void SetRandomInterval()
        {
            isInterval = true;
            note1 = GetRandomNote1();
            note2 = note1 + GetRandomInterval();
        }

        public void SetRandomNote()
        {
            isInterval = false;
            note1 = GetRandomNote1();
        }
    }
}
