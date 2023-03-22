<template>
    <div class="px-4 sm:px-6 lg:px-8 flow-root">
        <div class="-my-2 -mx-4 sm:-mx-6 lg:-mx-8">
          <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
            <table class="min-w-full border-separate">
              <thead>
                <tr class="divide-x sticky">
                  <th class="sticky overflow-y-hidden top-0 z-10 py-3.5 pl-4 pr-4 text-left rounded-md text-sm font-semibold text-gray-900 bg-gray-100">Question</th>
                  <th class="sticky top-0 z-10 py-3.5 pl-4 pr-4 text-left text-sm rounded-md font-semibold text-gray-900 bg-gray-100">Answer</th>
                </tr>
              </thead>
              <tbody class="divide-y divide-gray-200 bg-white">
                <tr v-for="person in people" :key="person.email" class="divide-x divide-gray-200">
                  <td class="whitespace-nowrap w-1/3 overflow-y-hidden max-w-[80px] py-4 pl-4 pr-4 text-sm font-medium text-gray-900 sm:pl-0">{{ person.name }}</td>
                  <td class="whitespace-nowrap w-2/3 overflow-y-hidden max-w-screen-sm py-4 pl-4 pr-4 text-sm text-gray-500 sm:pr-0">{{ person.role }}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
  </template>
  
  <script setup>
  const people = [
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'MemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMemberMember' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
    // More people...
  ]
  </script>