using Fluxor;
using IMS.WebApp.Store.Company.Actions.SelectCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Reducers
{
    public class SelectCompanyActionReducer
    {
        [ReducerMethod]
        public static CompanyState ReduceSelectCompanyAction(CompanyState state, SelectCompanyAction _) =>
            state with
            {
                IsLoading = true
            };

        [ReducerMethod]
        public static CompanyState ReduceSelectCompanySuccessAction(CompanyState state, SelectCompanySuccessAction action) =>
            state with
            {
                IsLoading = false,               
                CurrentCompany = action.Company                
            };

        [ReducerMethod]
        public static CompanyState ReduceSelectCompanyFailureAction(CompanyState state, SelectCompanyFailureAction action) =>
           state with
           {
               IsLoading = false,
               CurrentErrorMessage = action.ErrorMessage
           };
    }
}
