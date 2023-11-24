// About.js

import React from 'react';
import './about.css';

const About = () => {
  return (
    <div className="about-container">
      <div className="profile-section">
        <img
          src="your-profile-image.jpg"
          alt="Your Name"
          className="profile-image"
        />
        <h1>Your Name</h1>
        <p>Web Developer</p>
      </div>
      <div className="info-section">
        <section>
          <h2>About Me</h2>
          <p>
            Hello! I'm a passionate web developer with expertise in React and
            front-end technologies. I love creating responsive and user-friendly
            web applications.
          </p>
        </section>
        <section>
          <h2>Skills</h2>
          <ul>
            <li>React.js</li>
            <li>JavaScript</li>
            <li>HTML</li>
            <li>CSS</li>
            {/* Add more skills as needed */}
          </ul>
        </section>
        <section>
          <h2>Education</h2>
          <p>
            Bachelor of Science in Computer Science<br />
            University Name, Graduation Year
          </p>
        </section>
        <section>
          <h2>Work Experience</h2>
          <div>
            <h3>Web Developer</h3>
            <p>Company Name, Location (Month Year - Present)</p>
            <ul>
              <li>Developed and maintained web applications using React.js</li>
              <li>Collaborated with cross-functional teams for project delivery</li>
              {/* Add more work experience details */}
            </ul>
          </div>
        </section>
        <section>
          <h2>Contact Information</h2>
          <p>Email: your.email@example.com</p>
          <p>LinkedIn: linkedin.com/in/yourusername</p>
          <p>GitHub: github.com/yourusername</p>
          {/* Add more contact information as needed */}
        </section>
      </div>
    </div>
  );
};

export default About;
