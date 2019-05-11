
$("#teacherForm").submit(function (e) {
    e.preventDefault();
    var data = JSON.stringify(getTeacher());
    console.log(data);
    
    $.ajax({
        type: "POST",
        url: HOST + "/api/teacher/add",
        contentType: 'application/json',
        data: data,
        success: alert("done"),
        dataType: "json"
    });

});

$(document).on('click', '.addCourse', function (e) {
    e.preventDefault();
   
    $('.courseRowParent').append("<input type='text'/>"); 
});

$(document).on('click', '.removeCourse', function (e) {
    e.preventDefault();
    $(this).closest('.courseRow').remove();
});


function getTeacher() {
    var objects = {
       
       Course: courseList()
    };


      var formArray = $(".teacherDetail").find("input").serializeArray();
    for (var i = 0; i < formArray.length; i++) {
        objects[formArray[i]['name']] = formArray[i]['value'];
    }
    return objects;
}

function CourseList() {

}
