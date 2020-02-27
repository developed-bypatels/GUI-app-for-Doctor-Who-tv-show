<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Home extends CI_Controller {

  var $TPL;

  public function __construct()
  {
    parent::__construct();
    $this->load->database();
    $query = $this->db->query("SELECT * FROM courses_table;");
    $this->TPL['courses_table'] = $query->result_array();
    $query = $this->db->query("SELECT * FROM workshops_table;");
    $this->TPL['workshops_table'] = $query->result_array();
    $this->TPL['isActive'] = "home";
    // Your own constructor code
  }

  public function index()
  {
    $this->template->show('home', $this->TPL);
      
  } 
}
