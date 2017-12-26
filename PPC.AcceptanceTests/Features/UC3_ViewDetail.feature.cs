﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace PPC.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class UC3_ViewDetailFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "UC3_ViewDetail.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UC3_ViewDetail", "\tAs a user\r\n\tI want to be view project detail", ProgrammingLanguage.CSharp, new string[] {
                        "automated3"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "UC3_ViewDetail")))
            {
                global::PPC.AcceptanceTests.Features.UC3_ViewDetailFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "PropertyName",
                        "Avarta",
                        "Images",
                        "PropertyType",
                        "Content",
                        "Street",
                        "Ward",
                        "District",
                        "Price",
                        "UnitPrice",
                        "Area",
                        "BedRoom",
                        "BathRoom",
                        "PackingPlace",
                        "Agency",
                        "Create_at",
                        "Create_post",
                        "Status",
                        "Note",
                        "Update_at",
                        "Sale"});
            table1.AddRow(new string[] {
                        "PIS Top Apartment",
                        "PIS_6656-Edit-stamp.jpg",
                        "PIS_7319-Edit-stamp.jpg,",
                        "Apartment",
                        "The surrounding neighborhood is very much localized with a great number of local " +
                            "shops.",
                        "Thôn Chúc Đồng",
                        "Đại Yên",
                        "Chương Mỹ",
                        "10000",
                        "VND",
                        "120m2",
                        "3",
                        "2",
                        "1",
                        "Ly Chau",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Ly Chau"});
            table1.AddRow(new string[] {
                        "ViLa Q7",
                        "sunshine-benthanh-cityhome-10-stamp.jpg",
                        "PIS_7319-Edit-stamp.jpg,",
                        "Villa",
                        "Brand new apartments with unbelievable river and city view, completely renovated " +
                            "and tastefully furnished.",
                        "Số 39",
                        "TT Xuân Mai",
                        "Chương Mỹ",
                        "70000",
                        "VND",
                        "120m2",
                        "3",
                        "4",
                        "1",
                        "son",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Ly Chau"});
            table1.AddRow(new string[] {
                        "PIS Serviced Apartment – Style",
                        "sunshine-benthanh-cityhome-10-stamp.jpg",
                        "PIS_7389-Edit-stamp.jpg,sunshine-benthanh-cityhome-10-stamp.jpg",
                        "Office",
                        "The well equipped kitchen is opened on a cozy living room and a dining area with " +
                            "table and chairs..",
                        "Thôn Chúc Đồng",
                        "Đại Yên",
                        "Chương Mỹ",
                        "30000",
                        "VND",
                        "130m2",
                        "2",
                        "3",
                        "1",
                        "son",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Ly Chau"});
            table1.AddRow(new string[] {
                        "Vinhomes Central Park L2 – Duong’s Apartment",
                        "PIS_7389-Edit-stamp.jpg",
                        "PIS_7319-Edit-stamp.jpg,",
                        "Villa",
                        "Vinhomes Central Park is a new development that is in the heart of everything tha" +
                            "t Ho Chi Minh has to offer.",
                        "Số 39",
                        "TT Xuân Mai",
                        "Chương Mỹ",
                        "110000",
                        "VND",
                        "150m2",
                        "4",
                        "2",
                        "1",
                        "Ly Chau",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Ly Chau"});
            table1.AddRow(new string[] {
                        "Saigon Pearl Ruby Block",
                        "PIS_7319-Edit-stamp.jpg",
                        "PIS_7319-Edit-stamp.jpg,",
                        "Apartment",
                        "Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker " +
                            "Area, 23/9 park…",
                        "Thôn Chúc Đồng",
                        "Đại Yên",
                        "Chương Mỹ",
                        "30000",
                        "VND",
                        "130m2",
                        "3",
                        "5",
                        "1",
                        "Ly Chau",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Ly Chau"});
            table1.AddRow(new string[] {
                        "ICON 56 – Modern Style Apartment",
                        "PIS_7432-Edit-stamp.jpg",
                        "PIS_7432-Edit-stamp.jpg,",
                        "Villa",
                        "ICON 56 – Modern Style Apartment $ 950 Per Month Condominium in Rentals 56 Ben Va" +
                            "n Don, Ho Chi Minh City Icon 56 is 4 star building with strategic location and e" +
                            "xcellent amenities including infinity swimming pool and modern gym",
                        "Quảng Phúc",
                        "Ba Trại",
                        "Ba Vì",
                        "30000",
                        "VND",
                        "130m2",
                        "2",
                        "3",
                        "1",
                        "son",
                        "2017-11-09",
                        "2017-11-09",
                        "Đã duyệt",
                        "Done",
                        "2017-11-23",
                        "Ly Chau"});
#line 6
 testRunner.Given("the following project", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("View Detail")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UC3_ViewDetail")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated3")]
        public virtual void ViewDetail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Detail", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 15
 testRunner.When("I press the button Detail in project \'PIS Top Apartment\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "PropertyName",
                        "Type",
                        "Price",
                        "Area"});
            table2.AddRow(new string[] {
                        "PIS Top Apartment",
                        "Apartment",
                        "10000",
                        "120m2"});
#line 16
 testRunner.Then("the result should show :", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
