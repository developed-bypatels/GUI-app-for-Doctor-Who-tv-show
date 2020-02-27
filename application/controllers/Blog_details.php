<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Blog_details extends CI_Controller {

  var $TPL;

  public function __construct()
  {
    parent::__construct();
    $this->load->database();
    $query = $this->db->query("SELECT * FROM courses_table;");
    $this->TPL['courses_table'] = $query->result_array();
    $query = $this->db->query("SELECT * FROM workshops_table;");
    $this->TPL['workshops_table'] = $query->result_array();
    // Your own constructor code
  }

  public function index()
  {
    $this->template->show('blog_details', $this->TPL);
      
  }
}
