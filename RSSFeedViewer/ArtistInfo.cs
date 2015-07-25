using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedViewer
{
    class ArtistInfo
    {
        public string title { get; set; }
        public string subTitle { get; set; }

        private List<ArtistItem> _Items = new List<ArtistItem>();

        public List<ArtistItem> Items
        {
            get
            {
                return this._Items;
            }
        }
    }
}
