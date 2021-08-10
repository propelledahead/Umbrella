using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella.Models.Pollmaker.ResponseModels {
    public class pollread_read_response {
        #region Getters and Setters
        private string _id = "";
        private string _search_terms = "";
        private int _page_number = 0;
        private int _results_per_page = 10;
        #endregion
        #region Getters and Setters
        public string id {
            get { return this._id; }
            set { this._id = value; }
        }
        public string search_terms {
            get { return this._search_terms; }
            set { this._search_terms = value; }
        }
        public int page_number {
            get { return this._page_number; }
            set { this._page_number = value; }
        }
        public int results_per_page {
            get { return this._results_per_page; }
            set { this._results_per_page = value; }
        }
        #endregion
        #region Methods
        public pollread_read_response() { }
        #endregion
    }
}