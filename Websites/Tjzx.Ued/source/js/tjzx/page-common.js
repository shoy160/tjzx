(function($,T,S){
    S.mix(T,{
       getJson:function(url,data,success,error){
           S.mix(data,{t:Math.random()});
           $.ajax({
              url:url,
               type:"post",
               dataType:"json",
               data:data,
               success:function(json){
                   success && S.isFunction(success) && success.call(this,json);
               },
               error:function(json){
                   error && S.isFunction(error) && error.call(this,json);
               }
           });
       }
    });
})(jQuery,TJZX,SINGER);