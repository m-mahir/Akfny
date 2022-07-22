import React from 'react';

import { Navbar, Nav, NavItem } from 'reactstrap';

const Footer = () => {
  return (
    <div
      style={{
        backgroundColor: '#3a3b50',
        color: 'white',
      }}
    >
      <Navbar>
        <Nav navbar>
          <NavItem>تطوير وتشغيل منصة أكفني © 2021</NavItem>
        </Nav>
      </Navbar>
    </div>
  );
};

export default Footer;
