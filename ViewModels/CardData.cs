using TWTodoList.Models;
using Microsoft.AspNetCore.Mvc;

namespace TWTodoList.ViewModels;

 public class CardData
 {
    public string Title { get; set; }  = string.Empty;
    public string Subtitle { get; set; }  = string.Empty;
    public string Content { get; set; }  = string.Empty;
 }