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

        public void Play(int note1)
        {
            MidiPlayer.OpenMidi();
            MidiPlayer.Play(new NoteOn(deltaTime,
                                       channel,
                                       GetNoteName(note1),
                                       maxVolume));
            System.Threading.Thread.Sleep(finishTime);
            MidiPlayer.CloseMidi();
        }

        public void Play(int note1, int interval)
        {
            MidiPlayer.OpenMidi();
            MidiPlayer.Play(new NoteOn(deltaTime,
                                       channel,
                                       GetNoteName(note1),
                                       maxVolume));
            System.Threading.Thread.Sleep(intervalTime);
            MidiPlayer.Play(new NoteOff(deltaTime,
                                        channel,
                                        GetNoteName(note1),
                                        maxVolume));
            MidiPlayer.Play(new NoteOn(deltaTime,
                                        channel,
                                        GetNoteName(note1 + interval),
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
                string direction = "up";

                if (note2 < note1)
                {
                    direction = "down";
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
