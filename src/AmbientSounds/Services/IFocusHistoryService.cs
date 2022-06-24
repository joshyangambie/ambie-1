﻿using AmbientSounds.Models;
using System;

namespace AmbientSounds.Services
{
    public interface IFocusHistoryService
    {
        /// <summary>
        /// Event raised when a new history is added.
        /// </summary>
        event EventHandler<FocusHistory?>? HistoryAdded;

        /// <summary>
        /// Updates active history that a segment had ended.
        /// </summary>
        /// <param name="sessionType">The type of segment that just ended.</param>
        void TrackSegmentEnd(SessionType sessionType);

        /// <summary>
        /// Closes the current active history and saves to disk.
        /// </summary>
        /// <param name="ticks">Utc ticks when the focus session completed.</param>
        void TrackHistoryCompletion(long utcTicks, SessionType lastCompletedSegmentType);

        /// <summary>
        /// Starts a new history to track. Note: any previous active history
        /// will be abandoned. (There shouldn't be an active history unless
        /// this service's sequence of operations was incorrectly called).
        /// </summary>
        /// <param name="utcTicks">The Utc ticks for the start time.</param>
        /// <param name="focusLength">Length of each focus segment.</param>
        /// <param name="restLength">Length of each rest segment.</param>
        /// <param name="repetitions">Number of repetitions.</param>
        void TrackNewHistory(long utcTicks, int focusLength, int restLength, int repetitions);

        /// <summary>
        /// Closes the current active history while being incomplete. 
        /// </summary>
        void TrackIncompleteHistory(long utcTicks, TimeSpan minutesRemainingForIncompleteSegment);
    }
}