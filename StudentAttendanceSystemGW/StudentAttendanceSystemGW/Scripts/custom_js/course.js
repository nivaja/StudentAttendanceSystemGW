alert("asdasd");
$("#testForm").submit(function (e) {
    e.preventDefault();
    var data = JSON.stringify({"CourseDescription": "New Course", "Teacher": [{"TeacherId":"1"}]});
    console.log(data);
    $.ajax({
        type: "POST",
        url:"/Courses/Create",
       
        data: data,
        success: alert("done"),
        dataType: "json"
    });
});

function makeJson(formArray) {
    var objects = {};
    for (var i = 0; i < formArray.length; i++) {
        objects[formArray[i]['name']] = formArray[i]['value'];
    }
    
    return objects;
}