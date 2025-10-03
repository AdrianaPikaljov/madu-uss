using System;
using System.IO;
using System.Media;

namespace madu
{
    class Sounds
    {
        private readonly string eatPath;
        private readonly string movePath;
        private readonly string gameOverPath;

        public Sounds()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            eatPath = Path.Combine(basePath, "food.wav");
            movePath = Path.Combine(basePath, "move.wav");
            gameOverPath = Path.Combine(basePath, "gameover.wav");
        }

        public void PlayEat()
        {
            PlaySound(eatPath);
        }

        public void PlayMove()
        {
            PlaySound(movePath);
        }

        public void PlayGameOver()
        {
            PlaySound(gameOverPath);
        }

        private void PlaySound(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    SoundPlayer sp = new SoundPlayer(path);
                    sp.Play();
                }
                else
                {
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
            }
        }
    }
}
