using System.CodeDom;
using Gost_Project.Data.Entities;
using Gost_Project.Data.Models;
using Microsoft.IdentityModel.Tokens;

namespace Gost_Project.Helpers;

public class SearchHelper
{
    private static readonly string[] parametersPriority = ["CodeOKS", "ActivityField", "AdoptionLevel", "Designation", "FullName", "AcceptanceDate", "CommissionDate", 
                                                    "Author", "AcceptedFirstTimeOrReplaced", "KeyWords", "KeyPhrases", "ApplicationArea",
                                                    "DocumentText", "Changes", "Amendments", "Harmonization", "Content"];
    
    public static void GetMatchingDocs(List<GetDocumentResponseModel> docs, SearchParametersModel parameters)
    {
        foreach (var parameter in parametersPriority)
        {
            var temp = new List<GetDocumentResponseModel>();
            
            var searchParameter = new object();
            searchParameter = parameters.GetType().GetProperty(parameter).GetValue(parameters, null);
            if (searchParameter is null) continue;
            
            foreach (var doc in docs)
            {
                var primary = doc.Primary;
                var actual = doc.Actual;
                
                var primaryParameter = new object();
                var actualParameter = new object();
                
                primaryParameter = primary.GetType().GetProperty(parameter).GetValue(primary, null);
                actualParameter = actual.GetType().GetProperty(parameter).GetValue(actual, null);
                

                if (primaryParameter is string)
                {
                    
                    if (!((string)(actualParameter ?? primaryParameter)).ToLower().Contains(((string)searchParameter).ToLower()))
                    {
                        continue;
                    }
                }
                else if (primaryParameter is DateTime)
                {
                    var date = actualParameter ?? primaryParameter;
                    if (((DateTime)date).Year != ((DateTime)searchParameter).Year)
                    {
                        continue;
                    }
                }
                else
                {
                    var docParameter = actualParameter ?? primaryParameter;
                    if (docParameter.ToString() != searchParameter.ToString())
                    {
                        continue;
                    }
                }
                
                temp.Add(doc);
            }

            docs = temp;
        }
    }
}