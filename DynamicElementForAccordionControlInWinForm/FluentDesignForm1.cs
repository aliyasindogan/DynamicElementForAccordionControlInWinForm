using DevExpress.XtraBars.FluentDesignSystem;
using DevExpress.XtraBars.Navigation;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DynamicElementForAccordionControlInWinForm
{
    public partial class FluentDesignForm1 : FluentDesignForm
    {
        #region Defines

        private AccordionControl accordionControl = new AccordionControl();
        private AccordionControlElement acMainMenu = new AccordionControlElement();
        private AccordionControlElement mainCategory = new AccordionControlElement();
        private AccordionControlElement mainSubCategory = new AccordionControlElement();
        private AccordionControlElement subCategory = new AccordionControlElement();
        private AccordionControlElement endSubCategory = new AccordionControlElement();
        private FakeData fakeData = new FakeData();

        #endregion Defines

        #region FluentDesignForm1

        public FluentDesignForm1()
        {
            InitializeComponent();
        }

        private void FluentDesignForm1_Load(object sender, EventArgs e)
        {
            accordionControl.Dock = DockStyle.Left;
            accordionControl.Parent = this;
            accordionControl.Size = new System.Drawing.Size(260, 577);
            accordionControl.ViewType = AccordionControlViewType.HamburgerMenu;
            AccordionControlFill();
        }

        #endregion FluentDesignForm1

        #region Methods

        private void AccordionControlFill()
        {
            var categories = fakeData.CreateFakeDate();
            accordionControl.ElementClick += new ElementClickEventHandler(this.accordionControl1_ElementClick);
            foreach (var itemMainCategory in categories.Where(x => x.SubCategoryID == 0).ToList())
            {
                mainCategory = mainCategory.Elements.Add();
                mainCategory.Text = itemMainCategory.CategoryName;
                mainCategory.Tag = itemMainCategory.CategoryClassName;
                mainCategory.Expanded = true;
                accordionControl.Elements.Add(mainCategory);
                var lisss = accordionControl.GetElements();
                var data = accordionControl.Elements.ToList();

                // Debug.WriteLine(">" + itemMainCategory.CategoryName);

                foreach (var itemMainSubCategory in categories.Where(x => x.SubCategoryID == itemMainCategory.Id).ToList())
                {
                    var newMainCategory = mainCategory.Elements.Add();
                    newMainCategory.Name = itemMainSubCategory.CategoryName;
                    newMainCategory.Text = itemMainSubCategory.CategoryName;
                    newMainCategory.Tag = itemMainSubCategory.CategoryClassName;
                    newMainCategory.Style = ElementStyle.Group;

                    //Debug.WriteLine("  >" + itemMainSubCategory.CategoryName);
                    foreach (var itemSubCategory in categories.Where(x => x.SubCategoryID == itemMainSubCategory.Id).ToList())
                    {
                        mainSubCategory = newMainCategory;
                        var newSubCategory = mainSubCategory.Elements.Add();
                        newSubCategory.Name = itemSubCategory.CategoryName;
                        newSubCategory.Text = itemSubCategory.CategoryName;
                        newSubCategory.Tag = itemSubCategory.CategoryClassName;
                        newSubCategory.Style = ElementStyle.Group;

                        //Debug.WriteLine("   >" + itemSubCategory.CategoryName);
                        foreach (var itemEndSubCategory in categories.Where(x => x.SubCategoryID == itemSubCategory.Id).ToList())
                        {
                            subCategory = newSubCategory;
                            subCategory.Elements.Add(new AccordionControlElement
                            {
                                Name = itemEndSubCategory.CategoryName,
                                Text = itemEndSubCategory.CategoryName,
                                Tag = itemEndSubCategory.CategoryClassName,
                                Style = ElementStyle.Item,
                            });
                        }
                    }
                }
            }
        }

        private void accordionControl1_ElementClick(object sender, ElementClickEventArgs e)
        {
            if (e.Element.Style == ElementStyle.Group)
                return;
            if (e.Element.Tag == null)
                return;

            MessageBox.Show(e.Element.Name.ToString() + "'e tıkladınız! ", "İşlem Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Methods
    }
}