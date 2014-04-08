using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radiostr.Model;

namespace Radiostr
{
    public class PlayerMessage
    {
        public int StationId { get; set; }
        public Track Track { get; set; }
        public PlayerCommandType PlayerCommand { get; set; }
    }

    public enum PlayerCommandType
    {
        Play,
        Pause,
        Stop
    }
}
