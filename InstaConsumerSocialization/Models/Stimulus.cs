using System;
using System.Collections.Generic;

namespace InstaConsumerSocialization.Models
{
    public class Stimulus
    {
        public int StimulusId { get; }
        public string StimulusName { get; }
        public string StimulusCaption { get; }
        public string StimulusImagePath { get; }
        public string StimulusAuthorProfileImagePath { get; }
        public DateTime StimulusDateTime { get; }
        public int StimulusAuthorId { get; }
        public IEnumerable<string> StimulusResponses { get; set; }
        public bool StimulusIsFavoritedByParticipant { get; set; }
        public int NumberOfFavorites { get; set; }
        public int NumberOfResponses { get; set; }
        public Stimulus(
            int stimulusId,
            string stimulusName,
            string stimulusCaption,
            string stimulusImagePath,
            string stimulusAuthorProfileImagePath,
            DateTime stimulusDateTime,
            int stimulusAuthorId,
            IEnumerable<string> stimulusResponses,
            bool stimulusIsFavoritedByParticipant,
            int numberOfFavorites,
            int numberOfResponses
            )
        {
            StimulusId = stimulusId;
            StimulusName = stimulusName;
            StimulusCaption = stimulusCaption;
            StimulusImagePath = stimulusImagePath;
            StimulusAuthorProfileImagePath = stimulusAuthorProfileImagePath;
            StimulusDateTime = stimulusDateTime;
            StimulusAuthorId = stimulusAuthorId;
            StimulusResponses = stimulusResponses;
            StimulusIsFavoritedByParticipant = stimulusIsFavoritedByParticipant;
            NumberOfFavorites = numberOfFavorites;
            NumberOfResponses = numberOfResponses;
        }
        public string StimuliNamesAsString => string.Join(", ", StimulusName);
    }
}