using System;

namespace Radiostr.Helpers
{
    public class MbidHelper : IMbidHelper
    { 
        public string GetMbidUri(string mbid)
        {
            if (string.IsNullOrEmpty(mbid)) throw new ArgumentNullException("mbid");

            string uri = string.Format("http://musicbrainz.org/recording/{0}", mbid);

            if (new Uri(uri).ToString() != uri) throw new InvalidOperationException("MBID is mal-formed: " + mbid);

            return uri;
        }
    }
}