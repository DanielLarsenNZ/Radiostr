// WIP

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radiostr.Model;

namespace Radiostr
{
    interface ISelector
    {
        //delegate void NextTrackHandler(Selector selector, EventArgs eventArgs);
        //event Selector.NextTrackHandler NextTrack;

        void Start();

    }

    class Selector : ISelector
    {
        internal delegate void NextTrackHandler(Selector selector, SelectorEventArgs eventArgs);
        public event NextTrackHandler NextTrack;

        public void Start()
        {

        }
    }

    class SelectorEventArgs : EventArgs
    {
        public PlayerMessage PlayerMessage { get; set; }
    }
}
