using System;

namespace DancingGoat.Areas.Api.Dto
{
    public class CafeDto
    {
        #region "Properties"

        /// <summary>
        /// CafeID.
        /// </summary>
        
        public int CafeID { get; set; }


        /// <summary>
        /// Name.
        /// </summary>
        public string CafeName { get; set; }


        /// <summary>
        /// Our cafe.
        /// </summary>
        public bool CafeIsCompanyCafe { get; set; }


        /// <summary>
        /// Street.
        /// </summary>
        public string CafeStreet { get; set; }

        /// <summary>
        /// City.
        /// </summary>
       
        public string CafeCity { get; set; }


        /// <summary>
        /// Country.
        /// </summary>
       
        public string CafeCountry { get; set; }

        /// <summary>
        /// Zip code.
        /// </summary>
       
        public string CafeZipCode { get; set; }


        /// <summary>
        /// Phone.
        /// </summary>
       
        public string CafePhone { get; set; }

        /// <summary>
        /// Additional notes.
        /// </summary>
       
        public string CafeAdditionalNotes { get; set; }
    }

    #endregion

}
