using System;
using System.Threading.Tasks;
using Radiostr.Model;

namespace Radiostr.Services
{
    /// <summary>
    /// Defines a service that selects a time-based list of tracks based on some selection criteria or algorithm.
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Selects a Schedule containing the specified number of tracks.
        /// </summary>
        Task<Schedule> Select(int stationId, int[] libraryIds, int trackCount);

        /// <summary>
        /// Selects a Schedule of at least the specified duration.
        /// </summary>
        Task<Schedule> Select(int stationId, int[] libraryIds, TimeSpan duration);

        /// <summary>
        /// Selects a Schedule for broadcast at startTime for at least the specified duration.
        /// </summary>
        Task<Schedule> Select(int stationId, int[] libraryIds, DateTime startTime, DateTimePrecision precision, TimeSpan duration);
    }
}
