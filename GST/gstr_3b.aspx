<%@ Page Title="" Language="C#" MasterPageFile="~/GST/GST.master" AutoEventWireup="true" CodeFile="gstr_3b.aspx.cs" Inherits="GST_gstr_3b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>GSTR 3B</h1>
      <ol class="breadcrumb">
        <li><a href="#">GST</a></li>
        <li><i class="fa fa-angle-right"></i> GSTR 3B</li>
      </ol>
    </section>
    <section class="content">
      <div class="row m-b-3">
        
        <div class="col-md-12">
          <div class="card">
            
            <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#jan" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">January</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#feb" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">February</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#march" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">March</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#april" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">April</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#may" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">May</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#june" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">June</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#july" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">July</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#aug" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">August</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#sep" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">September</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#oct" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">October</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#nov" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">November</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#dec" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">December</span></a> </li>
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="jan" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="feb" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                 <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s2_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s2_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s2_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s2_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p2_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p2_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p2_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

                </div>
              </div>
              

           <div class="tab-pane p-20" id="march" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s3_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s3_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s3_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s3_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p3_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p3_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p3_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

              
                </div>
              </div>


              <div class="tab-pane p-20" id="april" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s4_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s4_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s4_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s4_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p4_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p4_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p4_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

              
                </div>
              </div>


                  <div class="tab-pane p-20" id="may" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s5_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s5_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s5_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s5_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p5_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p5_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p5_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

              
                </div>
              </div>


                  <div class="tab-pane p-20" id="june" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s6_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s6_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s6_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s6_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p6_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p6_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p6_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

              
                </div>
              </div>



                  <div class="tab-pane p-20" id="july" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s7_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s7_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s7_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s7_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p7_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p7_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p7_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

              
                </div>
              </div>



                  <div class="tab-pane p-20" id="aug" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s8_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s8_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s8_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s8_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p8_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p8_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p8_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

              
                </div>
              </div>



                  <div class="tab-pane p-20" id="sep" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s9_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s9_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s9_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s9_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p9_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p9_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p9_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

              
                </div>
              </div>



                  <div class="tab-pane p-20" id="oct" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s10_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s10_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s10_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s10_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p10_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p10_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p10_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

              
                </div>
              </div>


                  <div class="tab-pane p-20" id="nov" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s11_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s11_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s11_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s11_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p11_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p11_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p11_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

              
                </div>
              </div>


                  <div class="tab-pane p-20" id="dec" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
            <div class="col-lg-6">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h4>Total Taxable Value : ₹ <asp:Label ID="lbl_s12_total_taxable" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>IGST : ₹ <asp:Label ID="lbl_s12_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>              
              <h4>CGST : ₹ <asp:Label ID="lbl_s12_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/> 
              <h4>SGST : ₹ <asp:Label ID="lbl_s12_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
           
            <div class="tile-footer">
              <h3>Sale</h3>
            </div>
          </div>
        </div>
                <div class="col-lg-6">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
             
              <h4>IGST : ₹ <asp:Label ID="lbl_p12_igst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>CGST : ₹ <asp:Label ID="lbl_p12_cgst" runat="server" Text=""></asp:Label></h4>
                <hr class="hrcolor"/>
              <h4>SGST : ₹ <asp:Label ID="lbl_p12_sgst" runat="server" Text=""></asp:Label></h4>
            </div>
            
            <div class="tile-footer">
              <h3>Purchase</h3>
            </div>
          </div>
        </div>     

 </div>
              </div>
            </div>  

              
                </div>
              </div>


            </div>
          </div>
        </div>
      </div>
      <!-- row --> 
      
      
      <!-- Main row --> 
    </section>



    </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>


   
</asp:Content>

