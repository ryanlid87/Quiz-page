
<html lang="en">
<head>
  <meta charset="utf-8">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>


<script> 
$(document).ready(function(){
    //copies all contents of myDropDownListDiv into anotherDiv
    $("#Q2").html($("#myDropDownListDiv").html());
    $("#Q3").html($("#myDropDownListDiv").html());
    $("#Q4").html($("#myDropDownListDiv").html());
    $("#Q5").html($("#myDropDownListDiv").html());
    $("#Q6").html($("#myDropDownListDiv").html());
    $("#Q7").html($("#myDropDownListDiv").html());
    $("#Q8").html($("#myDropDownListDiv").html());
    $("#Q9").html($("#myDropDownListDiv").html());
    $("#Q10").html($("#myDropDownListDiv").html());

});
</script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>

<script language="JavaScript">

<!-- Begin
// Insert number of questions
var numQues = 10;

// Insert number of choices in each question
var numChoi = 9;

// Insert number of questions displayed in answer area
var answers = new Array(4);

// Insert answers to questions
answers[0] = "Missing Component";
answers[1] = "None";
answers[2] = "Tombstoned";
answers[3] = "Upside Down";
answers[4] = "Missing Component";
answers[5] = "Skewed";
answers[6] = "Insufficient Solder";
answers[7] = "None";
answers[8] = "Upside Down";
answers[9] = "None";

// Calculate Score
function getScore(form) {
  var score = 0
  var currSelection;
  for (j=0; j<numChoi+1; j++) {
      currSelection = form.elements.itemname[j].value;
      if (currSelection == answers[j]) {
          score++;
        }
      }
  
  score = Math.round(score / numQues * 100);
  form.percentage.value = score;
  form.scorevalue.value = score;
  var correctAnswers = "";
  for (i=1; i<=numQues; i++) {
    correctAnswers += i + ". " + answers[i-1] + "\r\n";
  }
  form.solutions.value = correctAnswers;
}
//  End -->
</script>

</HEAD>

<body>

<h3>Quiz 1</h3>


    <form name="quiz" method="post">
        1. <img src="~/Images/Quiz1/1.jpg" width="300" height="200">
        <ul style="margin-top: 1pt">
            <div id="myDropDownListDiv">
                <select id="itemname">
                    <option value="">Choose Defect</option>
                    <option value="Contamination">Contamination</option>
                    <option value="Fillet Error">Fillet Error</option>
                    <option value="Insufficient Solder">Insufficient Solder</option>
                    <option value="Missing Component">Missing Component</option>
                    <option value="Skewed">Skewed</option>
                    <option value="Solder Balls">Solder Balls</option>
                    <option value="Tombstoned">Tombstoned</option>
                    <option value="Upside Down">Upside Down</option>
                    <option value="Wrong Polarity">Wrong Polarity</option>
                    <option value="None">No Issue</option>
                   
                </select>
            </div>
        </ul>

        2. <img src="~/Images/Quiz1/2.jpg" width="229" height="460">
        <ul style="margin-top: 1pt">
            <div id="Q2">
            </div>
        </ul>
        3. <img src="~/Images/Quiz1/3.jpg" width="200" height="460">
        <ul style="margin-top: 1pt">
            <div id="Q3">
            </div>
        </ul>
        4. <img src="~/Images/Quiz1/4.jpg" width="300" height="200">
        <ul style="margin-top: 1pt">
            <div id="Q4">
            </div>
        </ul>
        5. <img src="~/Images/Quiz1/5.jpg" width="300" height="200">
        <ul style="margin-top: 1pt">
            <div id="Q5">
            </div>
        </ul>
        6. <img src="~/Images/Quiz1/6.jpg" width="300" height="200">
        <ul style="margin-top: 1pt">
            <div id="Q6">
            </div>
        </ul>
        7. <img src="~/Images/Quiz1/7.jpg" width="300" height="200">
        <ul style="margin-top: 1pt">
            <div id="Q7">
            </div>
        </ul>
        8. <img src="~/Images/Quiz1/8.jpg" width="300" height="200">
        <ul style="margin-top: 1pt">
            <div id="Q8">
            </div>
        </ul>
        9. <img src="~/Images/Quiz1/9.jpg" width="300" height="200">
        <ul style="margin-top: 1pt">
            <div id="Q9">
            </div>
        </ul>
        10. <img src="~/Images/Quiz1/10.jpg" width="300" height="200">
        <ul style="margin-top: 1pt">
            <div id="Q10">
            </div>
        </ul>

        <input type="submit" value="Get score" onclick="getScore(this.form)" >
        <input runat="server" name="scorevalue" id="scorevalue" type="hidden" />
        <input runat="server" name="sols" id="sols" type="hidden" />
        <input runat="server" name="username" id="username" value=@WebSecurity.CurrentUserName type="hidden">
        <p>
            Score = <strong><input class="bgclr" type="text" size="5" name="percentage" id="percentage" disabled></strong><br><br>
            Correct answers:<br>
            <textarea class="bgclr" name="solutions" wrap="virtual" rows="4" cols="30" disabled></textarea>
    </form>

@Code
    If Not User.Identity.IsAuthenticated Then
        Response.Redirect("~/Account/Login.vbhtml")
    End If
    
    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Quiz1"
    ' Initialize general page variables
    Dim score = Request.Form("scorevalue")
    Dim username As String
    username = Request.Form("username")
    Session("scorevalue") = score
    
    
    ' If this is a POST request, validate and process data
    If IsPost Then
        Dim answers = Request.Form("sols")
        Dim db As Database = Database.Open("CIProduction")
        Dim test = db.QueryValue("Select test1 from TouchupTraining where username=@0", username)
        If IsDBNull(test) Then
            db.Execute("update TouchupTraining set test1=@0 where username=@1", score, username)
        Else
            db.Execute("update TouchupTraining set test1=@0 where username=@1", test, username)
        End If
    End If
    
End Code
</html>
