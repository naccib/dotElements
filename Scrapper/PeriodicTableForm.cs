using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Scrapper
{
    public partial class PeriodicTableForm : Form
    {
        private readonly string[] Elements = "h,he,li,be,b,c,n,o,f,ne,na,mg,al,si,p,s,cl,ar,k,ca,sc,ti,v,cr,mn,fe,co,ni,cu,zn,ga,ge,as,se,br,kr,rb,sr,y,zr,nb,mo,tc,ru,rh,pd,ag,cd,in,sn,sb,te,i,xe,cs,ba,la,ce,pr,nd,pm,sm,eu,gd,tb,dy,ho,er,tm,yb,lu,hf,ta,w,re,os,ir,pt,au,hg,ti,pb,bi,po,at,rn,fr,ra,ac,th,pa,u,np,pu,am,cm,bk,cf,es,fm,md,no,lr,rf,db,sg,bh,mt,ds,rg,uub,uut,uuq,uup,uuh,uus,uuo".Split(new char[] { ',' });

        private readonly string[] DangerElements = "rf,db,sg,bh,hs,mt,ds,rg,pm,no,pu,am,cm,bk,cf,es,fm,md,no,lr".Split(new char[] { ',' });
        private readonly string[] LiquidElements = "hg,br".Split(new char[] { ',' });
        private readonly string[] AerialElements = "h,he,n,o,f,cl,ne,ar,kr,xe,rn".Split(new char[] { ',' });

        private readonly string[] AlcalineMetals = "li,na,k,rb,cs,fr,al,ga,ge,in,sn,sb,ti,pb,bi,po,uut,uuq,uup,uuh".Split(new char[] { ',' });
        private readonly string[] AlcalinosTerrosos = "be,mg,ca,sr,ba,ra".Split(new char[] { ',' }); // sla como eh em inglês, foda-se
        private readonly string[] TransitionMetals = "sc,ti,v,cr,mn,fe,co,ni,cu,zn,y,zr,nb,mo,tc,ru,rh,pd,ag,cd,la,hf,ta,w,re,os,ir,pt,au,hg,ac,rf,db,sg,bh,mt,ds,rg,uub".Split(new char[] { ',' });

        private readonly string[] Lantanideums = "ce,pr,nd,pm,sm,eu,gd,tb,dy,ho,er,tm,yb,lu".Split(new char[] { ',' });
        private readonly string[] Actinideums = "th,pa,u,np,pu,am,cm,bk,cf,es,fm,md,no,lr".Split(new char[] { ',' });

        private readonly string[] NonMetals = "b,c,si,p,s,as,se,te,i,at".Split(new char[] { ',' });


        public PeriodicTableForm()
        {
            InitializeComponent();
        }

        private void PeriodicTableForm_Load(object sender, EventArgs e)
        {
            //foreach (HighQualityPBox p in this.Controls.OfType<HighQualityPBox>())
            //    p.SizeMode = PictureBoxSizeMode.Zoom;

            customControl11.SizeMode = customControl12.SizeMode = customControl13.SizeMode = customControl14.SizeMode = customControl15.SizeMode =  PictureBoxSizeMode.Zoom;

            foreach (Control c in this.Controls.OfType<Button>())
            {
                try
                {
                    Button btn = c as Button;

                    int index = Convert.ToInt32(c.Text) - 1;
                    c.Text = Elements[index].Replace(Elements[index][0].ToString(), Elements[index][0].ToString().ToUpper());

                    btn.Click += (object a, EventArgs b) =>
                    {
                        new ElementShowForm(btn.Text.Replace("        ", "").ToLower()).ShowDialog();
                    };

                    EnfeitarTabela();
                }
                catch
                { }

            }
        }

        private void EnfeitarTabela()
        {
            foreach (Control c in this.Controls.OfType<Button>())
            {
                // prioriedade é: gases, líquidos e sintéticos

                Button btn = c as Button;
                if (DangerElements.ToList<string>().Contains(c.Text.ToLower()))
                {
                    btn.Image = Scrapper.Properties.Resources.dangerLittle;
                    btn.ImageAlign = ContentAlignment.MiddleLeft;

                    btn.Text = "        " + btn.Text;
                }

                if (AerialElements.ToList<string>().Contains(c.Text.ToLower()))
                {
                    btn.Image = Scrapper.Properties.Resources.aerial_new;
                    btn.ImageAlign = ContentAlignment.MiddleLeft;

                    btn.Text = "        " + btn.Text;
                }

                if (LiquidElements.ToList<string>().Contains(c.Text.ToLower()))
                {
                    btn.Image = Scrapper.Properties.Resources.liquid_one;
                    btn.ImageAlign = ContentAlignment.MiddleLeft;

                    btn.Text = "        " + btn.Text;
                }

                if(AlcalineMetals.ToList<string>().Contains(c.Text.ToLower()) || AlcalinosTerrosos.ToList<string>().Contains(c.Text.ToLower()) && btn.Image == null)
                {
                    btn.Image = Scrapper.Properties.Resources.terrosos;
                    btn.ImageAlign = ContentAlignment.MiddleLeft;

                    btn.Text = "        " + btn.Text;
                }

                if(TransitionMetals.ToList<string>().Contains(c.Text.ToLower()) && btn.Image == null)
                {
                    btn.Image = Scrapper.Properties.Resources.alcaline;
                    btn.ImageAlign = ContentAlignment.MiddleLeft;

                    btn.Text = "        " + btn.Text;
                }

                if (Actinideums.ToList<string>().Contains(c.Text.ToLower()))
                {
                    btn.Image = Scrapper.Properties.Resources.act;
                    btn.ImageAlign = ContentAlignment.MiddleLeft;

                    btn.Text = "        " + btn.Text;
                }

                if (Lantanideums.ToList<string>().Contains(c.Text.ToLower()))
                {
                    btn.Image = Scrapper.Properties.Resources.lantan;
                    btn.ImageAlign = ContentAlignment.MiddleLeft;

                    btn.Text = "        " + btn.Text;
                }

                if (NonMetals.ToList<string>().Contains(c.Text.ToLower()))
                {
                    btn.Image = Scrapper.Properties.Resources.non_metals;
                    btn.ImageAlign = ContentAlignment.MiddleLeft;

                    btn.Text = "        " + btn.Text;
                }
            }
        }
    }
}
