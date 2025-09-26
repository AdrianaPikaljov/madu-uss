using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    class Sounds
    {
        private readonly string eatPath;

        public Sounds()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            eatPath = Path.Combine("eat.wav");

        }


        public void PlayEat()
        {
            try
            {
                SoundPlayer eat = new SoundPlayer(eatPath);
                eat.Play();
            }
            catch {
            }
        }


    }
}

