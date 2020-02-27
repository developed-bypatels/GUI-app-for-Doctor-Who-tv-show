<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Contact extends CI_Controller {

  var $TPL;

  public function __construct()
  {
    parent::__construct();
    $this->load->database();
    $query = $this->db->query("SELECT * FROM courses_table;");
    $this->TPL['courses_table'] = $query->result_array();
    $query = $this->db->query("SELECT * FROM workshops_table;");
    $this->TPL['workshops_table'] = $query->result_array();
    $this->TPL['isActive'] = "contact";
    // Your own constructor code
  }

  public function index()
  {
    $this->template->show('contact', $this->TPL);
      
  }   
}
