using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web;
using Windows.Web.Syndication;

namespace RSSFeedViewer
{
    class ArtistDataSource
    {
        private string uriString = "http://datafeeds.rouxacademy.com/rss/";
   
        private ArtistInfo _info;

        public ArtistInfo info
        {
            get
            {

                return this._info;
            }
        }


        public async Task<ArtistInfo> GetFeedAsyc()
        {
            SyndicationClient client = new SyndicationClient();

            string feedURI = uriString + "artists.xml";

            Uri feed = new Uri(feedURI);

            try
            {
                SyndicationFeed sFeed = await client.RetrieveFeedAsync(feed);

                _info = new ArtistInfo();
                _info.title = sFeed.Title.Text;
                _info.subTitle = sFeed.Subtitle.Text;

                foreach (SyndicationItem item in sFeed.Items)
                {
                    ArtistItem rssItem = new ArtistItem();
                    rssItem.artistName = item.Title.Text;

                    if (sFeed.SourceFormat == SyndicationFormat.Rss20)
                    {
                        rssItem.biography = item.Summary.Text;
                        rssItem.artistPhoto = uriString + "images/artistsSmall/" + item.Links[0].NodeValue;
                        rssItem.artworkPhoto = uriString + "images/artistsLarge/" + item.Links[0].NodeValue;
                    }

                    _info.Items.Add(rssItem);
                }
                return _info;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
