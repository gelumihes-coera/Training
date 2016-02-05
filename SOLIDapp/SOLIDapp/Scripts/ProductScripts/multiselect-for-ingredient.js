//var Ingredients = (function () {
//    var privates = {};

//    privates.callPlugin = function() {
//        $("#ingredients-list").multiselect({
//            maxHeight: 200,
//            checkboxName: 'multiselect[]'
//        });
//    }

//    return {
//        init: privates.callPlugin()
//    }
//});



var Ingredients = {}
Ingredients = {
    
    callPlugin: function() {
        $("#ingredients-list").multiselect({
            maxHeight: 300,
            checkboxName: 'multiselect[]',
        });
    }
}