(function(w){

    "use strict";

    if( w.addEventListener ){
        w.addEventListener( "load", tjzx.wideMode, false );
        w.addEventListener( "resize", tjzx.wideMode, false );
    }
    else if( w.attachEvent ){
        w.attachEvent( "onload", tjzx.wideMode );
        w.attachEvent( "onresize", tjzx.wideMode );
    }
})(this);