
(function ($) {
	"use strict";
// Use Morris.Area instead of Morris.Line

// ======
// Yearly Earning Starts
    // ======

	var day_data= new Array();
	var donutData = [];
	$.ajax({
	    type: "post",
	    url: "Default.aspx/getGraphData",
	    contentType: "application/json; charset=utf-8",
	    dataType: "json",
	    success: function (response) {
	        var f = response.d;
	        var length = f.length;
	        //alert(f);
	        var salesTotal = 0;
	        var earningTotal = 0;
	        console.log(f.expenseData);
	        
               
	        $.each(f, function (key,value) {
	            //alert(JSON.stringify(this.month));
	            salesTotal += parseInt(this.stotal);
	            earningTotal += parseInt(this.etotal);
	            if (key <= length - 2) {
	                day_data.push({ elapsed: this.month, Sales: this.stotal, Purchase: this.etotal })
	            }

	            if(key == length-1){
	                $.each(this.expenseData, function (ekey, evalue) {
	                    donutData.push({ value: evalue.value, label: evalue.lable });
	                });
	                }

	                //donutData.push({ value: this.piChart.qty, label: 'Sale qty.' },
                    //    {value:this.piChart.salary,label:'Paid salary'},
                    //    {value:this.piChart.exp,label:'Total expences'});
	           
	        });
	        document.getElementById("salesTotalLable").innerHTML = "₹ " + salesTotal.toLocaleString(
  undefined, // leave undefined to use the browser's locale,
             // or use a string like 'en-US' to override it.
  { minimumFractionDigits: 2 }
);
	        document.getElementById("earningTotalLable").innerHTML = "₹ " + earningTotal.toLocaleString(
  undefined, // leave undefined to use the browser's locale,
             // or use a string like 'en-US' to override it.
  { minimumFractionDigits: 2 }
);;
	    },
	    failure: function (response) {
	        alert("fail");
	    },
	    async:false,
	});

//var day_data = [
//  {"elapsed": "2012", "Sales": 60, "Earning": 80},
//  {"elapsed": "2013", "Sales": 120, "Earning": 130},
//  {"elapsed": "2014", "Sales": 70, "Earning": 50},
//  {"elapsed": "2015", "Sales": 200, "Earning": 155},
//  {"elapsed": "2016", "Sales": null, "Earning": null},
//  {"elapsed": "2018", "Sales": null, "Earning": null},
//  {"elapsed": "2018", "Sales": null, "Earning": null}
//];
Morris.Line({
  element: 'earning',
  data: day_data,
  xkey: 'elapsed',
  ykeys: ['Sales', 'Purchase'],
  labels: ['Sales', 'Purchase'],
  fillOpacity: 0,
  pointStrokeColors: ['#1976d2', '#00a65a'],
  behaveLikeLine: true,
  gridLineColor: '#e0e0e0',
  lineWidth: 3,
  hideHover: 'auto',
  lineColors: ['#0077d3', '#00a65a'],
  parseTime: false,
  resize: true
});



// ======
// Yearly Earning Ending
// ======

// ======
// Donut Chart Starts
// ======

Morris.Donut({
      element: 'donut',
      data: donutData,
      backgroundColor: '#fff',
      labelColor: '#404e67',
      colors: [
        '#ff4558',
        '#ff7d4d',
        '#00a5a8'
      ],
      formatter: function (x) { return x }
    });

document.getElementById("Donut1").innerHTML = donutData[0].value;
document.getElementById("Donut2").innerHTML = donutData[1].value;
document.getElementById("Donut3").innerHTML = donutData[2].value;


// ======
// Donut chart End
// ======

})(jQuery);