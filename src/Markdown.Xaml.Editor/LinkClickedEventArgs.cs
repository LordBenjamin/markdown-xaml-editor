using System;

namespace Markdown.Xaml.Editor {
    public class LinkClickedEventArgs : EventArgs {
        private string uri;

        public LinkClickedEventArgs(string uri) {
            this.uri = uri;
        }

        public string Uri {
            get { return uri; }
        }
    }
}
