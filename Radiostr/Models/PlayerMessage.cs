//WIP
namespace Radiostr.Models
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
