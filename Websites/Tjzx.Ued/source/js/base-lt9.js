(function(w,S){
    "use strict";
    if( w.addEventListener ){
        w.addEventListener( "load", S.wideMode, false );
        w.addEventListener( "resize", S.wideMode, false );
    }
    else if( w.attachEvent ){
        w.attachEvent( "onload", S.wideMode );
        w.attachEvent( "onresize", S.wideMode );
    }
})(this,singer);