using System.ComponentModel.DataAnnotations;

namespace TestingControllersSample.ClientModels
{
    #region snippet_HomeController
   
        public class NewSessionModel
        {
            [Required]
            public string SessionName { get; set; }
        }
    
    #endregion
}
