$(function(){
  var symbols = {
    show: ' (click to expand)', //&#9654;
    hide: '&#9660;'
  }

  $('.hideable').append(' <span></span>')
    .attr('href', '#')
    .find('span').html(symbols.hide);
  $('.hideable').click(function(e){
    var target = $(this).attr('data-target');
    var $e = $('#' + target);
    if($e.is(':visible')){
      $(this).find('span').html(symbols.show);
      $e.hide();
    }else{
      $(this).find('span').html(symbols.hide);
      $e.show().addClass('flash');
    }
    e.preventDefault();
  })
});