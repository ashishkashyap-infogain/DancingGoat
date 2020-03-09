/*! Built with http://stenciljs.com */
components.loadBundle("kentico-modal-dialog",["exports"],function(e){var t=window.components.h,o=function(){function e(){var e=this;this.baseUnit=16,this.isModified=!1,this.dialogHeight=250,this.defaultMessages={closeTooltip:"Close",unsavedChanges:"Are you sure you want to close the dialog?\n\n    You have unsaved changes.\n\n    Press OK to continue or Cancel to stay on the current page.",loaderMessage:"Loading"},this.getDialogWidth=function(){var t=parseInt(e.configuration.width,10);return e.configuration.maximized?window.document.documentElement.clientWidth-2*e.baseUnit:e.configuration.width.endsWith("%")?Math.floor(window.document.documentElement.clientWidth*(t/100)):e.configuration.width.endsWith("px")?t:void 0},this.onDialogClosed=function(t){t.stopPropagation(),e.isModified&&!confirm(e.messages.unsavedChanges)||e.close.emit()},this.getTopPosition=function(e,t){return"calc(("+t.documentElement.clientHeight+"px - "+e+"px)/2)"},this.setDialogPosition=function(){e.topPosition=e.getTopPosition(e.dialogHeight,document)},this.render=function(){var o=e.configuration,n=o.dialogIndex,i=o.theme,a=o.showFooter,s=o.title,r=o.applyButtonText,l=o.cancelButtonText,c=e.combineWithDefaultMessages(e.messages),d=c.applyTooltip,u=c.closeTooltip;return t("div",{class:"ktc-form-wrapper",onWheel:function(e){return e.preventDefault()},onClick:e.stopPropagation,onMouseDown:e.stopPropagation,onMouseUp:e.stopPropagation},!n&&t("div",{class:"ktc-modal-dialog__overlay",style:e.overlayStyle}),t("div",{class:"ktc-modal-dialog",ref:function(t){return e.dialogElement=t},style:e.modalDialogStyle},t("kentico-dialog-header",{ref:function(t){return e.dialogHeader=t},headerTitle:s,theme:i,closeTooltip:u,onClose:e.onDialogClosed}),e.configuration.showLoader&&t("div",{class:a?"ktc-loader-container-wrapper with-footer":"ktc-loader-container-wrapper"},t("kentico-loader",{loaderMessage:e.messages.loaderMessage})),t("slot",null),a&&t("div",{class:"ktc-modal-dialog__footer"},t("div",{class:"ktc-modal-dialog__footer-buttons"},t("button",{type:"button",class:"ktc-btn ktc-btn-default",onClick:e.onDialogClosed},l),t("div",{class:"ktc-modal-dialog__footer-buttons-spacer"}),t("button",{type:"button",class:"ktc-btn ktc-btn-primary",ref:function(t){return e.submitButton=t},title:d,onClick:function(){return e.apply.emit()}}," ",r," ")))))}}return e.prototype.adjustDialogHeight=function(e){this.dialogHeight=e,this.setDialogPosition()},Object.defineProperty(e.prototype,"overlayStyle",{get:function(){return{zIndex:this.getZIndex(this.configuration.openedDialogsCount-1).toString()}},enumerable:!0,configurable:!0}),Object.defineProperty(e.prototype,"modalDialogStyle",{get:function(){return{zIndex:(this.getZIndex(this.configuration.dialogIndex)+1).toString(),top:this.topPosition,width:this.getDialogWidth()+"px"}},enumerable:!0,configurable:!0}),e.prototype.componentDidLoad=function(){this.setDialogPosition()},e.prototype.getZIndex=function(e){return 10200+100*e},e.prototype.combineWithDefaultMessages=function(e){return void 0===e&&(e=this.defaultMessages),Object.assign({},this.defaultMessages,e)},e.prototype.stopPropagation=function(e){e.stopPropagation()},Object.defineProperty(e,"is",{get:function(){return"kentico-modal-dialog"},enumerable:!0,configurable:!0}),Object.defineProperty(e,"encapsulation",{get:function(){return"shadow"},enumerable:!0,configurable:!0}),Object.defineProperty(e,"properties",{get:function(){return{adjustDialogHeight:{method:!0},configuration:{type:"Any",attr:"configuration"},hostElement:{elementRef:!0},messages:{type:"Any",attr:"messages"},topPosition:{state:!0}}},enumerable:!0,configurable:!0}),Object.defineProperty(e,"events",{get:function(){return[{name:"close",method:"close",bubbles:!0,cancelable:!0,composed:!0},{name:"apply",method:"apply",bubbles:!0,cancelable:!0,composed:!0}]},enumerable:!0,configurable:!0}),Object.defineProperty(e,"style",{get:function(){return"[class*=\" icon-\"],[class^=icon-]{font-family:Core-icons;display:inline-block;speak:none;font-style:normal;font-weight:400;font-variant:normal;text-transform:none;line-height:1;font-size:16px;-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;background-image:none}[class^=icon-]:before{content:\"\\e619\"}.ktc-icon-only:before{content:none}.ktc-icon-disabled{opacity:.5}.ktc-action-disabled{cursor:not-allowed;color:#696663;background-color:#a3a2a2;background-image:repeating-linear-gradient(-45deg,rgba(189,187,187,0) 0,#bdbbbb 1px,#bdbbbb 2px,rgba(189,187,187,0) 3px,rgba(189,187,187,0) 4px)}.ktc-dropdown-disabled{cursor:not-allowed;background-image:repeating-linear-gradient(-45deg,rgba(189,187,187,0) 0,rgba(189,187,187,.25) 1px,rgba(189,187,187,.25) 2px,rgba(189,187,187,0) 3px,rgba(189,187,187,0) 4px)}.ktc-dropdown-disabled:hover{background-color:inherit;background-image:repeating-linear-gradient(-45deg,rgba(189,187,187,0) 0,rgba(189,187,187,.25) 1px,rgba(189,187,187,.25) 2px,rgba(189,187,187,0) 3px,rgba(189,187,187,0) 4px)}:host .ktc-modal-dialog__overlay{position:fixed;left:0;top:0;width:100%;height:100%;background-color:#696663;opacity:.5}:host .ktc-modal-dialog{position:fixed;min-height:250px;-webkit-box-sizing:content-box;box-sizing:content-box;-webkit-box-shadow:0 2px 5px 0 rgba(0,0,0,.5);box-shadow:0 2px 5px 0 rgba(0,0,0,.5);background-color:#fff;border-bottom:1px solid #d6d9d6;left:0;right:0;margin:0 auto}:host .ktc-modal-dialog .ktc-modal-dialog__footer{padding:0 16px;position:relative;height:64px;bottom:0;-webkit-box-sizing:border-box;box-sizing:border-box}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn{display:inline-block;padding:0 16px;margin:0;font-size:14px;font-family:\"Segoe UI Semibold\",Helvetica,Verdana,Arial,sans-serif;font-weight:600;line-height:32px;width:auto;height:32px;text-align:center;vertical-align:middle;text-decoration:none;cursor:pointer;border:none;border-radius:3px;white-space:nowrap;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;text-shadow:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn:focus{outline-color:transparent}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn:hover{color:#262524;text-decoration:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn.ktc-active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn:active{outline:0;background-image:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn.ktc-btn-disabled:not(.ktc-btn-icon),:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn:disabled:not(.ktc-btn-icon),:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn[disabled]:not(.ktc-btn-icon){cursor:not-allowed;color:#696663;background-color:#a3a2a2;background-image:repeating-linear-gradient(-45deg,rgba(189,187,187,0) 0,#bdbbbb 1px,#bdbbbb 2px,rgba(189,187,187,0) 3px,rgba(189,187,187,0) 4px);text-shadow:none;-webkit-box-shadow:none;box-shadow:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn.ktc-btn-icon.ktc-btn-disabled,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn.ktc-btn-icon[disabled]{opacity:.5}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn i{padding-right:8px;font-size:16px;position:relative}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn.ktc-icon-only{padding:0 8px;font-family:Core-icons}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn.ktc-icon-only.ktc-js-_move{cursor:move}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn.ktc-icon-only i{padding-right:0}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn+.ktc-btn{margin-left:8px}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn .ktc-cms-icon-30{font-size:8px;height:8px;width:8px;padding:0 4px}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default{color:#262524;background-color:#bdbbbb;margin:0;-webkit-box-shadow:#a3a2a2 0 -3px 0 inset;box-shadow:#a3a2a2 0 -3px 0 inset}.ktc-open .ktc-dropdown-toggle:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default.ktc-active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default:active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default:hover{color:#262524;background-color:#a3a2a2}.ktc-open .ktc-dropdown-toggle:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default.ktc-active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default:active{background-image:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default i{color:#403e3d}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-primary{color:#fff;background-color:#497d04;margin:0;-webkit-box-shadow:#355e00 0 -3px 0 inset;box-shadow:#355e00 0 -3px 0 inset}.ktc-open .ktc-dropdown-toggle:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-primary,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-primary.ktc-active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-primary:active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-primary:hover{color:#fff;background-color:#355e00}.ktc-open .ktc-dropdown-toggle:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-primary,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-primary.ktc-active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-primary:active{background-image:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-primary .ktc-badge{color:#fff}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-secondary{color:#fff;background-color:#1175ae;margin:0;-webkit-box-shadow:#0f6194 0 -3px 0 inset;box-shadow:#0f6194 0 -3px 0 inset}.ktc-open .ktc-dropdown-toggle:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-secondary,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-secondary.ktc-active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-secondary:active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-secondary:hover{color:#fff;background-color:#0f6194}.ktc-open .ktc-dropdown-toggle:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-secondary,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-secondary.ktc-active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-secondary:active{background-image:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-secondary .ktc-badge{color:#fff}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default:active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default:hover{color:#262524;background-color:#a3a2a2;border-color:#a3a2a2;-webkit-box-shadow:#a3a2a2 0 -3px 0 inset;box-shadow:#a3a2a2 0 -3px 0 inset}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default:active .ktc-badge,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default:hover .ktc-badge{color:#262524}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default.ktc-active{background:#1175ae;color:#fff;-webkit-box-shadow:#0f6194 0 -3px 0 inset;box-shadow:#0f6194 0 -3px 0 inset}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-default.ktc-active .ktc-badge{color:#fff}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-icon{background:0 0;color:#403e3d;-webkit-box-shadow:none;box-shadow:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-icon.ktc-btn{margin:0;font-family:Core-icons}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-icon:hover[disabled]{color:#403e3d}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-icon:focus,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-icon:hover:not([disabled]){text-decoration:none;background:0 0;-webkit-box-shadow:none;box-shadow:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-icon:focus i,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-icon:hover:not([disabled]) i{color:#0f6194}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-icon .ktc-icon-disabled{pointer-events:none;cursor:not-allowed}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-icon .ktc-icon-disabled:hover{color:inherit}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-link{color:#0f6194;font-weight:400;cursor:pointer;border-radius:0;text-decoration:underline}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-link,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-link:active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-link[disabled]{background-color:transparent;-webkit-box-shadow:none;box-shadow:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-link,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-link:active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-link:hover{border-color:transparent}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-link:hover{color:#0f6194;text-decoration:underline;background-color:transparent}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-link[disabled]:hover{color:#bdbbbb;text-decoration:none}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-dropdown{position:relative;display:inline-block;vertical-align:middle}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-dropdown>.ktc-btn{position:relative;float:left}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-dropdown>.ktc-btn.ktc-active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-dropdown>.ktc-btn:active,:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-dropdown>.ktc-btn:hover{z-index:2}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-dropdown>.ktc-btn>.ktc-caret{color:#403e3d;font-size:8px;height:8px;width:8px;padding:0 8px 0 4px;position:relative;right:-16px;bottom:2px;border:none;vertical-align:baseline}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-btn-dropdown>.ktc-btn:focus{outline:0}:host .ktc-modal-dialog .ktc-modal-dialog__footer:before{content:'';border-bottom:1px solid #d6d9d6;width:100%;display:block}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-modal-dialog__footer-buttons{text-align:right;padding:16px 0}:host .ktc-modal-dialog .ktc-modal-dialog__footer .ktc-modal-dialog__footer-buttons .ktc-modal-dialog__footer-buttons-spacer{width:8px;display:inline-block}:host .ktc-modal-dialog .ktc-loader-container-wrapper{position:relative;min-height:214px}:host .ktc-modal-dialog .ktc-loader-container-wrapper .with-footer{min-height:150px}"},enumerable:!0,configurable:!0}),e}();e.KenticoModalDialog=o,Object.defineProperty(e,"__esModule",{value:!0})});